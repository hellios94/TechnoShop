using AutoMapper;
using System;
using Technoshop.Data;

namespace Technoshop.Services
{
    public class BaseEFService
    {

        public BaseEFService(
            TechnoshopContext dbContext,
            IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }


        protected TechnoshopContext DbContext { get; set; }

        protected IMapper Mapper { get; set; }
    }
}
