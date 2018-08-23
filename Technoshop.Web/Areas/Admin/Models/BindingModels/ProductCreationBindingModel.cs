using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Web.Areas.Admin.Models.BindingModels
{
    public class ProductCreationBindingModel
    {

        [Required]
        [Display(Name ="Model")]
        public string ModelName { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
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

        [Required]
        [Url]
        [Display(Name = "Product's Image Url")]
        public string ProductImageUrl { get; set; }

        [Required]
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
