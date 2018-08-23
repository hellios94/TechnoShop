using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Data;

namespace Technoshop.Tests.Mocks
{
    public static class MockDbContext
    {
        public static TechnoshopContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TechnoshopContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            return new TechnoshopContext(options);
        }
    }
}
