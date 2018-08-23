using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Models;

namespace Technoshop.Common.Buyer.ViewModels
{
    public class OrderProductViewModel
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
