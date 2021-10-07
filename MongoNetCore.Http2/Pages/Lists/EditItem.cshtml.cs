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
    public class EditItemModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditItemModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public EditItem Input { get; set; }

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

            Input = new EditItem
            {
                Completed = item.Completed,
                Description = item.Description,
                ItemId = item.Id,
                ListId = list.Id,
                Title = item.Title
            };

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

            var list = await _toDoListService.FindAsync(Input.ListId);

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

            var item = list.Items.FirstOrDefault(m => m.Id == Input.ItemId);

            item.Completed = Input.Completed;
            item.Description = Input.Description;
            item.Title = Input.Title;

            list.Items.ForEach(i =>
            {
                if (i.Id == item.Id)
                {
                    i = item;
                }
            });

            await _toDoListService.UpdateAsync(list);

            return Redirect($"/Lists/Items?id={list.Id}");
        }
    }
}
