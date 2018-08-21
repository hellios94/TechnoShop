using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Services.Admin.Interfaces;

namespace Technoshop.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminController
    {
        private readonly IAdminHomeService service;

        public HomeController(IAdminHomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await service.GetProductsAsync();
            return View(products);
        }
    }
}