using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Services.Admin.Interfaces
{
    public interface IAdminProductService
    {

        Task<ProductCreationBindingModel> PrepareProductForCreationAsync(int categoryId);

        Task<int> CreateProductAsync(ProductCreationBindingModel model);

        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId, string slug);

        Task<ProductRemoveViewModel> PrepareProductForRemoving(int? id, string slug);

        Task<Category> RemoveProductAsync(int id);

        Task<ProductEditBindingModel> PrepareProductForEditingAsync(int productId, string slug);

        Task EditProductAsync(int productId, ProductEditBindingModel model);
    }
}
