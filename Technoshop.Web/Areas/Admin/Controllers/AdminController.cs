using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Web.Constants;

namespace Technoshop.Web.Areas.Admin.Controllers
{

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class AdminController : Controller
    {
    }
}