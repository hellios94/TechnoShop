using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Web.Areas.Admin.Models.BindingModels
{
    public class CategoryCreationBindingModel
    {

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        [Url]
        public string CategoryPicUrl { get; set; }

    }
}
