using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Web.Helpers.Message;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Technoshop.Web.Extensions;

namespace Technoshop.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        private readonly IAdminCategoryService categoryService;

        public CategoriesController(IAdminCategoryService categoryService)
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

                
            var categoryId = await this.categoryService.AddCategoryAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Category created successfully."
            });

            return RedirectToAction("Details", new { id = categoryId, slug = model.Slug});
        }

        [HttpGet]
        [Route("admin/categories/details/{id}/{slug}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var category = await this.categoryService.GetCategoryDetailsAsync(id, slug);

            return View(category);
        }
    }
}