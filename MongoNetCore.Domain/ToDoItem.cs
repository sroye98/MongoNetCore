using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNetCore.Domain
{
    public class ToDoItem
    {
        public ToDoItem()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; } = false;

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
