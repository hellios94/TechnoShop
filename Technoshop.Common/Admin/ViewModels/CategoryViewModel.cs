using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Common.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
