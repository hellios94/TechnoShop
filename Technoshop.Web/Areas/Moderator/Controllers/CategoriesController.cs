using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Services.Moderator.Interfaces;

namespace Technoshop.Web.Areas.Moderator.Controllers
{
    public class CategoriesController : ModeratorController
    {
        private readonly IModeratorCategoryService categoryService;

        public CategoriesController(IModeratorCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this.categoryService.GetCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        [Route("moderator/categories/details/{id}/{slug}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var category = await this.categoryService.GetCategoryDetailsAsync(id, slug);
            return View(category);
        }
    }
}