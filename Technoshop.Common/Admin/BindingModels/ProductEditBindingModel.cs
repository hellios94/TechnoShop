using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Models;

namespace Technoshop.Common.Admin.BindingModels
{
    public class ProductEditBindingModel
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string ModelName { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "The description must be between 50 and 500 symbols.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Image is Required.")]
        [Url(ErrorMessage = "This is not valid Url.")]
        [Display(Name = "Product's Image Url")]
        public string ProductImageUrl { get; set; }

        [Required(ErrorMessage = "The price is Required.")]
        [Range(0.1, 100000, ErrorMessage = "The price must be between 0.1 and 100000 levs.")]
        public double Price { get; set; }

    }
}
