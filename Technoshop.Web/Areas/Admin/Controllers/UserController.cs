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
using Technoshop.Services.Admin.Interfaces;

namespace Technoshop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IAdminUserService service;

        public UserController(
            IAdminUserService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.service.GetAllUsersAsync(this.User);
            return View(model);
           
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await this.service.GetUserDetailsAsync(id, this.User);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeModerator(string id)
        {
            var model = await this.service.PrepareUserforModeratorAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeModerator(string id, string role)
        {
            await this.service.MakeUserModeratorAsync(id, role);

            return RedirectToAction("Details", new {id = id });
        }

        [HttpGet]
        public async Task<IActionResult> CancelModerator(string id)
        {

            var model = await this.service.PrepareUserforCancelModeratorAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CancelModerator(string id, string role)
        {
            await this.service.CancelUserModeratorAsync(id, role);
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Ban(string id)
        {
            var model = await this.service.PrepareUserforBanAsync(id);
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Ban (string id, string userName)
        {
            await this.service.BanUserAsync(id, userName);
            return RedirectToAction("Index");

        }
    }
}