using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Common.Buyer.ViewModels
{
    public class HomeConciseViewModel
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string ModelName { get; set; }

        public string ProductImageUrl { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
