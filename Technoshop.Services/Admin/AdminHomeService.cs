using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Services.Admin.Interfaces;

namespace Technoshop.Services.Admin
{
    public class AdminHomeService : BaseEFService, IAdminHomeService
    {
        public AdminHomeService(TechnoshopContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {

        }

        public async Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync()
        {
            var products = await this.DbContext.Products.ToListAsync();
            var productsModel = this.Mapper.Map<IEnumerable<HomeConciseViewModel>>(products);
            return productsModel;
        }
    }
}
