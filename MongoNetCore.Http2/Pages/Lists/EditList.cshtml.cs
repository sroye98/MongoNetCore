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
using MongoNetCore.Http2.Models.DTOs;

namespace MongoNetCore.Http2.Pages.Lists
{
    [Authorize]
    public class EditListModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditListModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public EditList Input { get; set; }

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

            Input = new EditList
            {
                ListId = list.Id,
                Name = list.ListName
            };

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

            list.ListName = Input.Name;

            await _toDoListService.UpdateAsync(list);

            return Redirect("/Lists/List");
        }
    }
}
