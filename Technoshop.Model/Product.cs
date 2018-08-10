using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Models
{
    public class Product
    {
        public Product()
        {
            this.Order = new List<ProductOrder>();
            this.Category = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public ICollection<CategoryProduct> Category { get; set; }

        public string Description { get; set; }

        public string CPUModel { get; set; }

        public string RAMType { get; set; }

        public int RAM { get; set; }

        public string StorageType { get; set; }

        public int Storage { get; set; }

        public string VideoCardModel { get; set; }

        public int VideoCardMemory { get; set; }

        public string ProductImageUrl { get; set; }

        public ICollection<ProductOrder> Order { get; set; }
    }
}
