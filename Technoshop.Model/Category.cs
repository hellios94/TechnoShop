using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Models
{
    public class Category
    {

        public Category()
        {
            this.Product = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> Product { get; set; }

    }
}
