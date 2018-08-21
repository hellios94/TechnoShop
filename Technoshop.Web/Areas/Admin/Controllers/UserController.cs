using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Data;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Models;
using Technoshop.Web.Constants;

namespace Technoshop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly TechnoshopContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserController(
            TechnoshopContext context,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var users = this.dbContext.Users.
                Where(u => u.Id != currentUser.Id).
                ToList();

            var model = this.mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                var date = await this.userManager.GetLockoutEndDateAsync(user);
                var dateNow = DateTime.Now;
                var mod = model.FirstOrDefault(m => m.Id == user.Id);
                    if (roles.Contains(WebConstants.AdminRole) && user.Id == mod.Id)
                    {
                        mod.IsAdmin = true;
                    }
                    else
                    {
                        mod.IsAdmin = false;
                    }
                    if (roles.Contains(WebConstants.ModeratorRole) && user.Id == mod.Id)
                    {
                        mod.IsModerator = true;
                    }
                    else
                    {
                        mod.IsModerator = false;
                    }
                    if(date > dateNow)
                    {
                        mod.IsBanned = true;
                    }
                    else
                    {
                        mod.IsBanned = false;
                    }

            }
            return View(model);
           
        }

        public async Task<IActionResult> Details(string id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (id == currentUser.Id)
            {
                return Unauthorized();
            }
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
                    
            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.mapper.Map<UserDetailsViewModel>(user);
            model.Roles = roles;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeModerator(string id)
        {
            var user = await this.dbContext.Users.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            var model = this.mapper.Map<MakeUserModeratorViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeModerator(string id, string role)
        {
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Details", new {id = user.Id });
        }

        [HttpGet]
        public async Task<IActionResult> CancelModerator(string id)
        {
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            var model = this.mapper.Map<CancelModeratorViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CancelModerator(string id, string role)
        {
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            await this.userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction("Details", new { id = user.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Ban(string id)
        {
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            var model = this.mapper.Map<BanUserViewModel>(user);
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Ban (string id, string userName)
        {
            var user = await this.dbContext.Users.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            var date = DateTime.Now;
            var endDate = date + TimeSpan.FromDays(30);

            await this.userManager.SetLockoutEndDateAsync(user, endDate);
            return RedirectToAction("Index");

        }
    }
}