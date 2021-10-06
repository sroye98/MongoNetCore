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

namespace MongoNetCore.Http.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public LoginUser Input { get; set; }

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

            var applicationUser = await _userManager.FindByEmailAsync(Input.Identifier) ?? await _userManager.FindByNameAsync(Input.Identifier);
            if (applicationUser == null)
            {
                return Redirect("/Error");
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                applicationUser,
                Input.Password,
                true,
                true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(
                    nameof(Input.Identifier),
                    "Login Failed: Invalid Email or Password");
            }

            return Redirect("/Submissions/List");
        }
    }
}
