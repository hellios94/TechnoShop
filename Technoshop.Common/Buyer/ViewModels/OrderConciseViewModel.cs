using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Common.Buyer.ViewModels
{
    public class OrderConciseViewModel
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<OrderProductViewModel> Products { get; set; }
    }
}
