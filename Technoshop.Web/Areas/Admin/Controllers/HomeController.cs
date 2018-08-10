using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Technoshop.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}