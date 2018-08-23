using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;

namespace Technoshop.Services.Moderator.Interfaces
{
    public interface IModeratorHomeService
    {

        Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync();

    }
}
