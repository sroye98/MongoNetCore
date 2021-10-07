using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Interfaces
{
    public interface IToDoListService
    {
        Task<ToDoList> CreateAsync(ToDoList toDoList);
        Task DeleteAsync(string id);
        Task<ToDoList> FindAsync(string id);
        Task<ToDoList> FindByItemIdAsync(string id);
        Task<IList<ToDoList>> ReadAsync(Guid userId);
        Task UpdateAsync(ToDoList list);
    }
}
