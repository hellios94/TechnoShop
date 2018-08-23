using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Services.Buyer.Interface;
using Technoshop.Services.Exceptions;

namespace Technoshop.Services.Buyer
{
    public class BuyerProductsService : BaseEFService, IBuyerProductsService
    {

        public BuyerProductsService(TechnoshopContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {

        }

        public async Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync()
        {
            var products = await this.DbContext.Products.ToListAsync();
            var productsModel = this.Mapper.Map<IEnumerable<HomeConciseViewModel>>(products);
            return productsModel;
        }

        public async Task<ProductDetailsViewModel> ProductDetailsAsync(int productId, string slug)
        {
            var product = await this.DbContext.Products.FindAsync(productId);
            if (product == null || product.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<ProductDetailsViewModel>(product);
            return model;
        }
    }
}
