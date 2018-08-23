using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;

namespace Technoshop.Services.Buyer.Interface
{
    public interface IBuyerProductsService
    {
        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId, string slug);

        Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync();

    }
}
