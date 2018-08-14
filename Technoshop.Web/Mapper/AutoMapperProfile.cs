using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Models;
using Technoshop.Web.Areas.Admin.Models.BindingModels;
using Technoshop.Web.Areas.Admin.Models.ViewModels;

namespace Technoshop.Web.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<CategoryCreationBindingModel, Category>();
            this.CreateMap<Category, CategoryConciseViewModel>();
            this.CreateMap<Category, CategoryDetailsViewModel>();
            this.CreateMap<Category, CategoryRemoveViewModel>();
            this.CreateMap<ProductCreationBindingModel, Product>();
            this.CreateMap<Product, ProductDetailsViewModel>();
            this.CreateMap<ProductEditViewModel, Product>();
            this.CreateMap<Product, ProductRemoveViewModel>();
        }

    }
}
