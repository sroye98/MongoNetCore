using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoNetCore.Application.Interfaces;
using MongoNetCore.Domain;
using MongoNetCore.Http.Models.DTOs;

namespace MongoNetCore.Http.Pages.Submissions
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ISubmissionService _submissionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(
            ISubmissionService submissionService,
            UserManager<ApplicationUser> userManager)
        {
            _submissionService = submissionService;
            _userManager = userManager;
        }

        [BindProperty]
        public CreateSubmission Input { get; set; }

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

            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            var submission = new Submission
            {
                Content = Input.Content,
                LastUpdated = DateTime.Now,
                UserId = currentApplicationUser.Id,
                UserName = currentApplicationUser.UserName
            };

            _submissionService.Create(submission);

            return Redirect("/Submissions/List");
        }
    }
}
