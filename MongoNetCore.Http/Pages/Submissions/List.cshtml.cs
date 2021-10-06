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

namespace MongoNetCore.Http.Pages.Submissions
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly ISubmissionService _submissionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ListModel(
            ISubmissionService submissionService,
            UserManager<ApplicationUser> userManager)
        {
            _submissionService = submissionService;
            _userManager = userManager;
        }

        public IList<Submission> SubmissionItems { get; set; }

        public ApplicationUser CurrentApplicationUser { get; set; }

        public async Task OnGetAsync()
        {
            CurrentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);
            SubmissionItems = _submissionService.Read();
        }
    }
}
