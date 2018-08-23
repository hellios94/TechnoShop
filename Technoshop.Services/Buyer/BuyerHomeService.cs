using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Services.Buyer.Interface;

namespace Technoshop.Services.Buyer
{
    public class BuyerHomeService : BaseEFService, IBuyerHomeService
    {
        public BuyerHomeService(TechnoshopContext dbContext, IMapper mapper)
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
