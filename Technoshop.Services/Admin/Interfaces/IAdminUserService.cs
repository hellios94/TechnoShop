using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.ViewModels;

namespace Technoshop.Services.Admin.Interfaces
{
    public interface IAdminUserService
    {

        Task<IEnumerable<UserConciseViewModel>> GetAllUsersAsync(ClaimsPrincipal user);

        Task<UserDetailsViewModel> GetUserDetailsAsync(string id, ClaimsPrincipal user);

        Task<MakeUserModeratorViewModel> PrepareUserforModeratorAsync(string id);

        Task MakeUserModeratorAsync(string id, string role);

        Task<CancelModeratorViewModel> PrepareUserforCancelModeratorAsync(string id);

        Task CancelUserModeratorAsync(string id, string role);

        Task<BanUserViewModel> PrepareUserforBanAsync(string id);

        Task BanUserAsync(string id, string userName);
    }
}
