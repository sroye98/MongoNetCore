using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoNetCore.Application.DTOs;
using MongoNetCore.Domain;

namespace MongoNetCore.Http2.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public CreateUser Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Properties");
                return Page();
            }

            ApplicationUser appUser = new ApplicationUser
            {
                UserName = Input.UserName,
                Email = Input.EmailAddress
            };

            IdentityResult result = await _userManager.CreateAsync(
                appUser,
                Input.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return Page();
            }

            //result = await _userManager.AddToRoleAsync(
            //    appUser,
            //    "User");
            //if (!result.Succeeded)
            //{
            //    foreach (IdentityError error in result.Errors)
            //        ModelState.AddModelError("", error.Description);
            //}

            return Redirect("/");
        }
    }
}
