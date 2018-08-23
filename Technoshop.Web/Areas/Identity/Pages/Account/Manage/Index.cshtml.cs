using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Technoshop.Models;
using Technoshop.Web.Models;

namespace Technoshop.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly IEmailSender EmailSender;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            EmailSender = emailSender;
        }

        public string Username { get; set; }



        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await UserManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            }

            var userName = await UserManager.GetUserNameAsync(user);
            var email = await UserManager.GetEmailAsync(user);
            var phoneNumber = await UserManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber
            };

            IsEmailConfirmed = await UserManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await UserManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            }

            var email = await UserManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await UserManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await UserManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await UserManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await UserManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await UserManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await SignInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await UserManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            }


            var userId = await UserManager.GetUserIdAsync(user);
            var email = await UserManager.GetEmailAsync(user);
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await EmailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
