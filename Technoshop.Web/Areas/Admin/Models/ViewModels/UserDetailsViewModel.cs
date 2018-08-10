﻿
using System.Collections.Generic;

namespace Technoshop.Web.Areas.Admin.Models.ViewModels
{
    public class UserDetailsViewModel
    {

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}