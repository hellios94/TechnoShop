using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.BindingModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Web.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<User, MakeUserModeratorViewModel>();
            this.CreateMap<User, CancelModeratorViewModel>();
            this.CreateMap<User, BanUserViewModel>();

            this.CreateMap<CategoryCreationBindingModel, Category>();
            this.CreateMap<Category, CategoryConciseViewModel>();
            this.CreateMap<Category, CategoryDetailsViewModel>();

            this.CreateMap<ProductCreationBindingModel, Product>();
            this.CreateMap<Product, ProductDetailsViewModel>();
            this.CreateMap<Product, ProductEditBindingModel>();
            this.CreateMap<Product, ProductRemoveViewModel>();
            this.CreateMap<ProductCreationBindingModel, Product>();
            this.CreateMap<Product, HomeConciseViewModel>();

            this.CreateMap<OrderCreationBindingModel, Order>();
            this.CreateMap<Order, OrderConciseViewModel>();
            this.CreateMap<OrderAddressCreationBindingModel, Order>();
        }

    }
}
