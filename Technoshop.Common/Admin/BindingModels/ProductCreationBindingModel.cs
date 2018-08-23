using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Models;

namespace Technoshop.Common.Admin.BindingModels
{
    public class ProductCreationBindingModel
    {

        [Required(ErrorMessage = "The model's name is required.")]
        [Display(Name ="Model")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "The Slug is required.")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "The Brand is required.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "The Category is required.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "The description must be between 50 and 500 symbols.")]
        public string Description { get; set; }

        [Display(Name = "CPU")]
        public string CPUModel { get; set; }

        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Display(Name = "Storage")]
        public string Storage { get; set; }

        [Display(Name = "Video Card Model")]
        public string VideoCardModel { get; set; }

        [Display(Name = "Video Card Memory")]
        public int VideoCardMemory { get; set; }

        [Required(ErrorMessage = "The Image is Required.")]
        [Url(ErrorMessage = "This is not valid Url.")]
        [Display(Name = "Product's Image Url")]
        public string ProductImageUrl { get; set; }

        [Required(ErrorMessage = "The Price is Required.")]
        [Range(0.1, 100000, ErrorMessage = "The price must be between 0.1 and 100000 levs.")]
        public double Price { get; set; }

        [Display(Name = "Operating System")]
        public string OS { get; set; }

        [Display(Name = "Front Camera")]
        public string FrontCamera { get; set; }

        [Display(Name = "Back Camera")]
        public string BackCamera { get; set; }

        public string Display { get; set; }

        public double Weight { get; set; }

        public string USB { get; set; }

        public string Ports { get; set; }

        public bool HDMI { get; set; }

        public string Battery { get; set; }
    }
}
