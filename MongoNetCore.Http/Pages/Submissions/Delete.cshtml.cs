using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoNetCore.Application.Interfaces;

namespace MongoNetCore.Http.Pages.Submissions
{
    public class DeleteModel : PageModel
    {
        private readonly ISubmissionService _submissionService;

        public DeleteModel(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [BindProperty]
        public string SubmissionId { get; set; }

        public IActionResult OnGet(string id)
        {
            var submission = _submissionService.Find(id);
            if (submission == null)
            {
                return Redirect("/Error");
            }

            SubmissionId = submission.Id;

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

            _submissionService.Delete(submission.Id);

            return Redirect("/Submissions/List");
        }
    }
}
