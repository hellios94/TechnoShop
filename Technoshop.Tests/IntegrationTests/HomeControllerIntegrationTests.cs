using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Web;

namespace Technoshop.Tests.IntegrationTests
{
    [TestClass]
    public class HomeControllerIntegrationTests
    {
        [TestMethod]
        public async Task Index_ShouldReturnIndexView()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            var result = await client.GetAsync("/");
            var resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}
