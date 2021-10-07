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
    public class DeleteItemModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteItemModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public string ItemId { get; set; }

        [BindProperty]
        public string ListId { get; set; }

        public async Task<IActionResult> OnGetAsync(string listId, string itemId)
        {
            var list = await _toDoListService.FindAsync(listId);

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

            var item = list.Items.FirstOrDefault(m => m.Id == itemId);

            ItemId = item.Id;
            ListId = list.Id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string listId, string itemId)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Properties");
                return Page();
            }

            var list = await _toDoListService.FindAsync(ListId);

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

            var item = list.Items.FirstOrDefault(m => m.Id == ItemId);

            list.Items.Remove(item);

            await _toDoListService.UpdateAsync(list);

            return Redirect($"/Lists/Items?id={list.Id}");
        }
    }
}
