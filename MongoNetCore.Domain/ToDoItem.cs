using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class ToDoItem : AuditableEntity
    {
        public ToDoItem()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; } = false;
    }
}
