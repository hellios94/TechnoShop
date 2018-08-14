using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Models
{
    public class Category
    {

        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string CategoryPicUrl { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
