using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Technoshop.Models
{
    public class User : IdentityUser
    {

        public User()
        {
            this.Order = new List<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}