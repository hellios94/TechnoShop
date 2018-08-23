using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Services.Exceptions;

namespace Technoshop.Services.Admin
{
    public class AdminUserService : BaseEFService, IAdminUserService
    {
        private readonly UserManager<User> userManager;

        public AdminUserService(TechnoshopContext dbContext, IMapper mapper, UserManager<User> userManager)
            :base(dbContext, mapper)
        {
            this.userManager = userManager;
        }


        public async Task BanUserAsync(string id, string userName)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            var date = DateTime.Now;
            var endDate = date + TimeSpan.FromDays(30);

            await this.userManager.SetLockoutEndDateAsync(user, endDate);
        }

        public async Task CancelUserModeratorAsync(string id, string role)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            await this.userManager.RemoveFromRoleAsync(user, role);

        }

        public async Task<IEnumerable<UserConciseViewModel>> GetAllUsersAsync(ClaimsPrincipal user)
        {
            var currentUser = await this.userManager.GetUserAsync(user);
            var users = this.DbContext.Users.
                Where(u => u.Id != currentUser.Id).
                ToList();

            var model = this.Mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            foreach (var userToSearch in users)
            {
                var roles = await this.userManager.GetRolesAsync(userToSearch);
                var date = await this.userManager.GetLockoutEndDateAsync(userToSearch);
                var dateNow = DateTime.Now;
                var modelToCheck = model.FirstOrDefault(m => m.Id == userToSearch.Id);
                if (roles.Contains("Admin") && userToSearch.Id == modelToCheck.Id)
                {
                    modelToCheck.IsAdmin = true;
                }
                else
                {
                    modelToCheck.IsAdmin = false;
                }
                if (roles.Contains("Moderator") && userToSearch.Id == modelToCheck.Id)
                {
                    modelToCheck.IsModerator = true;
                }
                else
                {
                    modelToCheck.IsModerator = false;
                }
                if (date > dateNow)
                {
                    modelToCheck.IsBanned = true;
                }
                else
                {
                    modelToCheck.IsBanned = false;
                }
            }
            return model;
        }

        public async Task<UserDetailsViewModel> GetUserDetailsAsync(string id, ClaimsPrincipal user)
        {
            var currentUser = await this.userManager.GetUserAsync(user);
            if (id == currentUser.Id)
            {
                throw new UnauthorizedAccessException();
            }
            var Modeluser = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            var roles = await this.userManager.GetRolesAsync(Modeluser);
            var model = this.Mapper.Map<UserDetailsViewModel>(Modeluser);
            model.Roles = roles;

            return model;
        }

        public async Task MakeUserModeratorAsync(string id, string role)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            await this.userManager.AddToRoleAsync(user, role);
        }

        public async Task<BanUserViewModel> PrepareUserforBanAsync(string id)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            var model = this.Mapper.Map<BanUserViewModel>(user);

            return model;
        }

        public async Task<CancelModeratorViewModel> PrepareUserforCancelModeratorAsync(string id)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            if (id == null)
            {
                throw new NotFoundException();
            }

            var model = this.Mapper.Map<CancelModeratorViewModel>(user);
            return model;
        }

        public async Task<MakeUserModeratorViewModel> PrepareUserforModeratorAsync(string id)
        {
            var user = await this.DbContext.Users.FindAsync(id);

            if (id == null)
            {
                throw new NotFoundException();
            }

            var model = this.Mapper.Map<MakeUserModeratorViewModel>(user);

            return model;
        }
    }
}
