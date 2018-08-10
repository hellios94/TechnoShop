using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Models
{
    public class Order
    {

        public Order()
        {
            this.Product = new List<ProductOrder>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<ProductOrder> Product { get; set; }

    }
}
