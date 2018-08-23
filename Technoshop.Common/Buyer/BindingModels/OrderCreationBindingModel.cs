using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Common.Buyer.BindingModels
{
    public class OrderCreationBindingModel
    {
        
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}
