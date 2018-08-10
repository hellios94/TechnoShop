using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Data;
using Technoshop.Web.Areas.Admin.Models.ViewModels;
using Technoshop.Models;

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
    }
}