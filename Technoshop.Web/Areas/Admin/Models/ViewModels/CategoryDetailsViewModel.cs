using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Web.Areas.Admin.Models.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
