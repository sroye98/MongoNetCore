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
    public class CreateItemModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateItemModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public CreateItem Input { get; set; }

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

            Input = new CreateItem
            {
                ListId = id
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid Properties");
                return Page();
            }

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

            var item = new ToDoItem
            {
                Completed = false,
                Created = DateTime.Now,
                Description = Input.Description,
                LastUpdated = DateTime.Now,
                Title = Input.Title,
                UserId = currentApplicationUser.Id,
                UserName = currentApplicationUser.UserName
            };

            list.Items.Add(item);

            await _toDoListService.UpdateAsync(list);

            return Redirect("/Lists/List");
        }
    }
}
