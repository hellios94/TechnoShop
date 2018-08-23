using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Common.Admin.ViewModels
{
    public class UserConciseViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsModerator { get; set; }

        public bool IsBanned { get; set; }
    }
}
