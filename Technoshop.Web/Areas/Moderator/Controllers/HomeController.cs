using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Services.Moderator.Interfaces;

namespace Technoshop.Web.Areas.Moderator.Controllers
{
    public class HomeController : ModeratorController
    {
        private readonly IModeratorHomeService service;

        public HomeController(IModeratorHomeService service)
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