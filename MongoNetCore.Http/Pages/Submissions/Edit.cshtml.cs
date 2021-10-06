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
    public class EditModel : PageModel
    {
        private readonly ISubmissionService _submissionService;

        public EditModel(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [BindProperty]
        public EditSubmission Input { get; set; }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/Error");
            }

            var submission = _submissionService.Find(id);
            if (submission == null)
            {
                return Redirect("/Error");
            }

            Input = new EditSubmission
            {
                Content = submission.Content,
                Id = submission.Id
            };

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Properties");
                return Page();
            }

            var submission = _submissionService.Find(id);
            if (submission == null)
            {
                return Redirect("/Error");
            }

            submission.Content = Input.Content;
            submission.LastUpdated = DateTime.Now;

            _submissionService.Update(submission);

            return Redirect("/Submissions/List");
        }
    }
}
