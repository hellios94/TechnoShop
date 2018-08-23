using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.BindingModels;
using Technoshop.Common.Buyer.ViewModels;

namespace Technoshop.Services.Buyer.Interface
{
    public interface IBuyerOrdersService
    {

        OrderConciseViewModel GetProductsFromOrder(ClaimsPrincipal user);

        Task AddProductToOrderAsync(int id, ClaimsPrincipal user);

        Task RemoveProductFromOrderAsync(int productId, ClaimsPrincipal user);

        void ClearShoppingCart(ClaimsPrincipal user);

        int FinalizeOrder(OrderAddressCreationBindingModel model, ClaimsPrincipal user);
    }
}
