using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.BindingModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Buyer.Interface;
using Technoshop.Services.Exceptions;

namespace Technoshop.Services.Buyer
{
    public class BuyerOrdersService : BaseEFService, IBuyerOrdersService
    {
        private readonly UserManager<User> userManager;

        public BuyerOrdersService(TechnoshopContext dbContext, IMapper mapper, UserManager<User> userManager)
            :base(dbContext, mapper)
        {
            this.userManager = userManager;
        }

        public async Task AddProductToOrderAsync(int id, ClaimsPrincipal user)
        {
            var product = await this.DbContext.Products.FindAsync(id);
            

            if (product == null || this.userManager.GetUserId(user) == null)
            { 
                throw new NotFoundException();
            }

            var order = this.DbContext.Orders.Include(o => o.Product).FirstOrDefault(o => o.UserId == this.userManager.GetUserId(user));

            if (order == null)
            {
                var model = new OrderCreationBindingModel()
                {
                    ProductId = product.Id,
                    UserId = this.userManager.GetUserId(user),
                    CreatedOn = DateTime.Now
                };
                order = this.Mapper.Map<Order>(model);
                await this.DbContext.Orders.AddAsync(order);
                ProductOrder orderedProduct = new ProductOrder()
                {
                    Product = product,
                    ProductId = product.Id,
                    Order = order,
                    OrderId = order.Id
                };
                order.Product.Add(orderedProduct);
                await this.DbContext.SaveChangesAsync();
            }
            else
            {
                ProductOrder orderedProduct = new ProductOrder()
                {
                    Product = product,
                    ProductId = product.Id,
                    Order = order,
                    OrderId = order.Id
                };
                order.CreatedOn = DateTime.Now;
                bool IsInOrder = false;
                foreach(var productToCheck in order.Product)
                {
                    if (productToCheck.ProductId == orderedProduct.ProductId)
                    {
                        IsInOrder = true;
                    }
                }
                if (IsInOrder)
                {

                }
                else
                {
                    order.Product.Add(orderedProduct);
                    await this.DbContext.SaveChangesAsync();
                }
            }
        }

        public void ClearShoppingCart(ClaimsPrincipal user)
        {
            var order = this.DbContext.Orders.Include(o => o.Product)
                .FirstOrDefault(o => o.UserId == this.userManager.GetUserId(user));
            order.Product.Clear();
            this.DbContext.Orders.Update(order);
            this.DbContext.SaveChanges();
        }

        public int FinalizeOrder(OrderAddressCreationBindingModel model, ClaimsPrincipal user)
        {
            var order = this.DbContext.Orders.Include(o => o.Product)
                .FirstOrDefault(o => o.UserId == this.userManager.GetUserId(user));
            order.Address = model.Address;
            order.City = model.City;
            order.Country = model.Country;
            order.Email = model.Email;
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.PhoneNumber = model.PhoneNumber;
            order.PostalCode = model.PostalCode;

            this.DbContext.Orders.Update(order);
            this.DbContext.SaveChanges();
            return order.Id;
        }

        public OrderConciseViewModel GetProductsFromOrder(ClaimsPrincipal user)
        {
            var order = this.DbContext.Orders.Include(o => o.Product)
                .FirstOrDefault(o => o.UserId == this.userManager.GetUserId(user));
            if (order != null)
            {
                order.User = this.DbContext.Users.FirstOrDefault(u => u.Id == order.UserId);
                foreach (var product in order.Product)
                {
                    product.Product = this.DbContext.Products.FirstOrDefault(p => p.Id == product.ProductId);
                }

                var model = this.Mapper.Map<OrderConciseViewModel>(order);
                model.Products = new List<OrderProductViewModel>();
                foreach (var product in order.Product)
                {
                    model.Products.Add(new OrderProductViewModel()
                    {
                        Order = product.Order,
                        OrderId = product.OrderId,
                        Product = product.Product,
                        ProductId = product.ProductId
                    });
                }
                return model;
            }
            else
            {
                var model = this.Mapper.Map<OrderConciseViewModel>(order);
                return model;
            }

        }

        public async Task RemoveProductFromOrderAsync(int productId, ClaimsPrincipal user)
        {
            var product = await this.DbContext.Products.FindAsync(productId);


            if (product == null || this.userManager.GetUserId(user) == null)
            {
                throw new NotFoundException();
            }

            var order = this.DbContext.Orders.Include(o => o.Product).FirstOrDefault(o => o.UserId == this.userManager.GetUserId(user));

            if (order == null)
            {
                throw new NotFoundException();
            }
            var productToRemove = new ProductOrder();
            foreach(var productToCheck in order.Product)
            {
                if(productToCheck.ProductId == productId)
                {
                    productToRemove = productToCheck;
                }
            }
            order.Product.Remove(productToRemove);
            this.DbContext.Orders.Update(order);
            await this.DbContext.SaveChangesAsync();
        }
    }
}
