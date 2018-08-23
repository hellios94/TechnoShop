using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Services.Interface.Buyer;

namespace Technoshop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IBuyerCategoryService service;

        public CategoryApiController(IBuyerCategoryService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            var categories = service.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = this.service.GetGategory(id);
            if (category == null)
            {
                return NotFound(new { Message = "The category does not exist."});
            }
            return Ok(category);
        }
    }
}