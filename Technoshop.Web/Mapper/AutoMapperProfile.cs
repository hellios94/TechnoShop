using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Models;
using Technoshop.Web.Areas.Admin.Models.ViewModels;

namespace Technoshop.Web.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
        }

    }
}
