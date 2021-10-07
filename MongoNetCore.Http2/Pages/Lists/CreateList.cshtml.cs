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
    public class CreateListModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateListModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        [BindProperty]
        public CreateList Input { get; set; }

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

            var list = new ToDoList
            {
                Created = DateTime.Now,
                Items = new List<ToDoItem>(),
                LastUpdated = DateTime.Now,
                ListName = Input.Name,
                UserId = currentApplicationUser.Id,
                UserName = currentApplicationUser.UserName
            };

            await _toDoListService.CreateAsync(list);

            return Redirect("/Lists/List");
        }
    }
}
