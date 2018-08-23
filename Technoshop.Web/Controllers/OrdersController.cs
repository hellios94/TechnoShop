using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Common.Buyer.BindingModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Services.Buyer.Interface;
using Technoshop.Web.Extensions;
using Technoshop.Web.Helpers.Message;

namespace Technoshop.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBuyerOrdersService service;

        public OrdersController(IBuyerOrdersService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = this.service.GetProductsFromOrder(this.User);
            var allAmount = 0.0;
            if (model != null)
            {
                foreach (var product in model.Products.ToList())
                {
                    allAmount += product.Product.Price;
                }
            }
            this.ViewData["AllAmount"] = allAmount;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int id)
        {
            await this.service.AddProductToOrderAsync(id: id, user: this.User);
            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Product was add to your card successfully."
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await this.service.RemoveProductFromOrderAsync(id, this.User);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult FinalizeOrder ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FinalizeOrder(OrderAddressCreationBindingModel model)
        {
            var orderId = this.service.FinalizeOrder(model, this.User);
            this.service.ClearShoppingCart(this.User);
            return RedirectToAction("SendedOrder");
        }

        [HttpGet]
        public IActionResult SendedOrder()
        {
            return View();
        }
    }
}