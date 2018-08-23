using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Services.Buyer.Interface;

namespace Technoshop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IBuyerCategoryService service;

        public CategoriesController(IBuyerCategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this.service.GetCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        [Route("categories/details/{id}/{slug}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var category = await this.service.GetCategoryDetailsAsync(id, slug);
            return View(category);
        }
    }
}