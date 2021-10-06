using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNetCore.Domain
{
    public class ToDoList
    {
        public ToDoList()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string ListName { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        public List<ToDoItem> Items { get; set; }
    }
}
