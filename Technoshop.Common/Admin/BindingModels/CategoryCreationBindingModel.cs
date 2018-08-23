using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Common.Admin.BindingModels
{
    public class CategoryCreationBindingModel
    {

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "The name must be between 5 and 150 symbols.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "The Slug is required.")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "The Image is Required.")]
        [Url(ErrorMessage = "This is not valid Url.")]
        [Display(Name = "Image")]
        public string CategoryPicUrl { get; set; }

    }
}
