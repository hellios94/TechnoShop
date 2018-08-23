using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Technoshop.Common.Buyer.BindingModels
{
    public class OrderAddressCreationBindingModel
    {
        [Required(ErrorMessage = "The first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The phone number is required.")]
        [Phone (ErrorMessage = "This is not valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Email is required.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "This is not valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The city is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The postal code is required.")]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode, ErrorMessage = "This is not valid Postal Code.")]
        public int PostalCode { get; set; }

    }
}
