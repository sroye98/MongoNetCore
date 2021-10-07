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

namespace MongoNetCore.Http2.Pages.Lists
{
    [Authorize]
    public class DeleteListModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteListModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public string ListId { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var list = await _toDoListService.FindAsync(id);

            if (list == null)
            {
                return Redirect("/Error");
            }

            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            if (list.UserId != currentApplicationUser.Id)
            {
                return Redirect("/Error");
            }

            ListId = list.Id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var list = await _toDoListService.FindAsync(id);

            if (list == null)
            {
                return Redirect("/Error");
            }

            var currentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            if (list.UserId != currentApplicationUser.Id)
            {
                return Redirect("/Error");
            }

            if (list.Items.Count() > 0)
            {
                ModelState.AddModelError(
                    "",
                    "Please remove all items in this list before deleting");
                return Page();
            }

            await _toDoListService.DeleteAsync(list.Id);

            return Redirect("/Lists/List");
        }
    }
}
