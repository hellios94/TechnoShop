using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Technoshop.Web.Constants;

namespace Technoshop.Web.Areas.Moderator.Controllers
{
    [Area(WebConstants.ModeratorArea)]
    [Authorize(Roles = WebConstants.ModeratorAreaRoles)]
    public class ModeratorController : Controller
    { 
    }
}