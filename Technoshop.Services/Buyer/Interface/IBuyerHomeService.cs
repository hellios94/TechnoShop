using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;

namespace Technoshop.Services.Buyer.Interface
{
    public interface IBuyerHomeService
    {

        Task<IEnumerable<HomeConciseViewModel>> GetProductsAsync();

    }
}
