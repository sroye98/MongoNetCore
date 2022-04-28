using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNetCore.Domain.Shared
{
    public class AuditableEntity : BaseEntity
    {
        public AuditableEntity()
        {
        }

        public Guid UserId { get; set; }

        public string UserName { get; set; }
    }
}
