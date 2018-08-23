using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;

namespace Technoshop.Services.Admin.Interfaces
{
    public interface IAdminHomeService
    {

        Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync();

    }
}
