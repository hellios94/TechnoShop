using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Technoshop.Web.Helpers.Message;
using Technoshop.Web.Extensions;

namespace Technoshop.Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
    {

        private readonly IAdminProductService productService;
        private readonly IAdminCategoryService categoryService;

        public ProductsController(IAdminProductService productService,
            IAdminCategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = await this.productService.PrepareProductForCreationAsync(categoryId: id);
            if (model == null)
            {
                return NotFound();
            }

            var categories = await this.categoryService.GetCategoryAsync(id);
            this.ViewData["Category"] = categories.Name;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreationBindingModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var productId = await this.productService.CreateProductAsync(model);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product added successfully."
            });

            return RedirectToAction("Details", new { id = productId, slug = model.Slug });
        }

        [HttpGet]
        [Route("admin/products/detials/{id}/{slug}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var product = await this.productService.ProductDetailsAsync(productId: id,slug: slug);
            var categories = await this.categoryService.GetCategoryAsync(product.CategoryId);
            this.ViewData["Category"] = categories.Name;
            this.ViewData["CategorySlug"] = categories.Slug;
            return View(product);
        }

        [HttpGet]
        [Route("admin/products/edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int id, string slug)
        {

            var product = await this.productService.PrepareProductForEditingAsync(productId: id, slug: slug);

            return View(product);
        }

        [HttpPost]
        [Route("admin/products/edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int id, string slug, ProductEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.productService.EditProductAsync(id, model);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product edited successfully."
            });

            return RedirectToAction("Details", new { id = id, slug = slug});
        }

        [HttpGet]
        [Route("admin/products/RemoveProduct/{id}/{slug}")]
        public async Task<IActionResult> RemoveProduct(int? id, string slug)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await this.productService.PrepareProductForRemoving(id, slug);

            return View(product);
        }

        [HttpPost]
        [Route("admin/products/RemoveProduct/{id}/{slug}")]
        public async Task<IActionResult> RemoveProduct (int id, string slug)
        {
            var category = await this.productService.RemoveProductAsync(id);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product Removed successfully."
            });

            return RedirectToAction("Details", "Categories", new { id = category.Id, slug = category.Slug});
        }
    }
}