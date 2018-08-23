using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Web.Mapper;

namespace Technoshop.Tests.Mocks
{
    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetMapper()
        {
            return Mapper.Instance;
        }

    }
}
