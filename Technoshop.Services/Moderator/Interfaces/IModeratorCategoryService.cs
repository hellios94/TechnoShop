using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Services.Moderator.Interfaces
{
    public interface IModeratorCategoryService
    {

        Task<IEnumerable<CategoryConciseViewModel>> GetCategoriesAsync();

        Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int id, string slug);

        Task<Category> GetCategoryAsync(int id);
    }
}
