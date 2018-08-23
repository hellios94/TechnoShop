using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Services.Buyer.Interface;

namespace Technoshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IBuyerProductsService productService;
        private readonly IBuyerCategoryService categoryService;

        public ProductsController(IBuyerProductsService productsService, IBuyerCategoryService categoryService)
        {
            this.productService = productsService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var product = await this.productService.ProductDetailsAsync(productId: id, slug: slug);
            var categories = await this.categoryService.GetCategoryAsync(product.CategoryId);
            this.ViewData["Category"] = categories.Name;
            this.ViewData["CategorySlug"] = categories.Slug;
            return View(product);
        }
    }
}