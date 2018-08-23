using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Services.Moderator.Interfaces;
using Technoshop.Web.Extensions;
using Technoshop.Web.Helpers.Message;

namespace Technoshop.Web.Areas.Moderator.Controllers
{
    public class ProductsController : ModeratorController
    {
        private readonly IModeratorProductsService productService;
        private readonly IModeratorCategoryService categoryService;

        public ProductsController(IModeratorProductsService productService,
            IModeratorCategoryService categoryService)
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

            var productId = await this.productService.CreateProductAsync(model, this.User);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product was added successfully."
            });

            return RedirectToAction("Details", new { id = productId, slug = model.Slug });
        }

        [HttpGet]
        [Route("moderator/products/detials/{id}/{slug}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var product = await this.productService.ProductDetailsAsync(productId: id, slug: slug);
            var categories = await this.categoryService.GetCategoryAsync(product.CategoryId);
            this.ViewData["Category"] = categories.Name;
            this.ViewData["CategorySlug"] = categories.Slug;
            return View(product);
        }

        [HttpGet]
        [Route("moderator/products/Edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int id, string slug)
        {

            var product = await this.productService.PrepareProductForEditingAsync(productId: id, slug: slug);

            return View(product);
        }

        [HttpPost]
        [Route("moderator/products/Edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int id, string slug, ProductEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.productService.EditProductAsync(id, model, this.User);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product was edited successfully."
            });

            return RedirectToAction("Details", new { id = id, slug = slug });
        }

        [HttpGet]
        [Route("moderator/products/RemoveProduct/{id}/{slug}")]
        public async Task<IActionResult> RemoveProduct(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productService.PrepareProductForRemoving(id, slug);

            return View(product);
        }

        [HttpPost]
        [Route("moderator/products/RemoveProduct/{id}/{slug}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await this.productService.RemoveProductAsync(id, this.User);

            this.TempData.Put("__Message", new MessageModel
            {
                Type = MessageType.Success,
                Message = "Product was Removed successfully."
            });

            return RedirectToAction("Details", "Categories", new { id = product.Id, slug = product.Slug});
        }
    }
}