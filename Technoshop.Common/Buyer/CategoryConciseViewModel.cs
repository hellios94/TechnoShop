using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Common.Buyer.ViewModels
{
    public class CategoryConciseViewModel
    {

        public int Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string CategoryPicUrl { get; set; }
    }
}
