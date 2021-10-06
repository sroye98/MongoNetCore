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
    public class ListModel : PageModel
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ListModel(
            IToDoListService toDoListService,
            UserManager<ApplicationUser> userManager)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
        }

        public IList<ToDoList> ToDoLists { get; set; }

        public ApplicationUser CurrentApplicationUser { get; set; }

        public async Task OnGetAsync()
        {
            CurrentApplicationUser = await _userManager.FindByEmailAsync(User.Identity.Name) ??
                await _userManager.FindByNameAsync(User.Identity.Name);
            ToDoLists = await _toDoListService.ReadAsync(CurrentApplicationUser.Id);
        }
    }
}
