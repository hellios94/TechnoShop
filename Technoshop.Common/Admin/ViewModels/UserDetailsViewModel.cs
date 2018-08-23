using System.Collections.Generic;

namespace Technoshop.Common.Admin.ViewModels
{
    public class UserDetailsViewModel
    {

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; } = "http://www.progarchives.com/forum/uploads/45302/robot.png";

        public IEnumerable<string> Roles { get; set; }

    }
}