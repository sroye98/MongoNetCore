using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class ToDoList : AuditableEntity
    {
        public ToDoList()
        {
        }

        public string ListName { get; set; }

        public List<ToDoItem> Items { get; set; }
    }
}
