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
    public class ItemsModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemsModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        public ToDoList ToDoList { get; set; }

        public ApplicationUser CurrentApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ToDoList = await _toDoListService.FindAsync(id);

            if (ToDoList == null)
            {
                return Redirect("/Error");
            }

            CurrentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);

            if (ToDoList.UserId != CurrentApplicationUser.Id)
            {
                return Redirect("/Error");
            }

            return Page();
        }
    }
}
