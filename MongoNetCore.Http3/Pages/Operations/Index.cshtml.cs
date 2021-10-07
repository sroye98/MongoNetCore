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

namespace MongoNetCore.Http3.Pages.Operations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICaseService _caseService;
        private readonly IClinicService _clinicService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(
            ICaseService caseService,
            IClinicService clinicService,
            UserManager<ApplicationUser> userManager)
        {
            _caseService = caseService;
            _clinicService = clinicService;
            _userManager = userManager;
        }

        public IList<Case> Cases { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            await _clinicService.SetupAsync();

            if (!string.IsNullOrEmpty(id))
                Cases = await _caseService.ReadByClinicIdAsync(id);
            else
                Cases = await _caseService.ReadAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            var clinics = await _clinicService.ReadAsync();
            var cases = await _caseService.ReadAsync();
            await _caseService.CreateAsync(
                new Case
                {
                    Clinic = clinics.First(),
                    SurgeryName = $"Surgery {cases.Count + 1}",
                    SurgeryNickname = (cases.Count + 1).ToString(),
                    UserId = currentApplicationUser.Id,
                    UserName = currentApplicationUser.UserName,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    Notes = "Something new"
                });

            return Redirect("/Operations");
        }

        public async Task<IActionResult> OnPostUpdateClinicAsync()
        {
            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            var clinics = await _clinicService.ReadAsync();

            var clinic = clinics.First();
            clinic.Name = "Clinic 45";
            await _clinicService.UpdateAsync(clinic);

            var cases = await _caseService.ReadByClinicIdAsync(clinic.Id);
            var _cases = cases.ToList();
            _cases.ForEach(async @case =>
            {
                @case.Clinic = clinic;
                await _caseService.UpdateAsync(@case);
            });

            return Redirect("/Operations");
        }

        public async Task<IActionResult> OnPostChangeClinicAsync()
        {
            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            var clinics = await _clinicService.ReadAsync();
            var cases = await _caseService.ReadAsync();

            var @case = cases.First();
            @case.Clinic = clinics[1];
            await _caseService.UpdateAsync(@case);

            return Redirect("/Operations");
        }
    }
}
