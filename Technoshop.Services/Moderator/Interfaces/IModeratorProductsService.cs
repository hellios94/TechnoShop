using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Services.Moderator.Interfaces
{
    public interface IModeratorProductsService
    {

        Task<ProductCreationBindingModel> PrepareProductForCreationAsync(int categoryId);

        Task<int> CreateProductAsync(ProductCreationBindingModel model, ClaimsPrincipal user);

        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId, string slug);

        Task<ProductRemoveViewModel> PrepareProductForRemoving(int? id, string slug);

        Task<Category> RemoveProductAsync(int id, ClaimsPrincipal user);

        Task<ProductEditBindingModel> PrepareProductForEditingAsync(int productId, string slug);

        Task EditProductAsync(int productId, ProductEditBindingModel model, ClaimsPrincipal user);

    }
}
