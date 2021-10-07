using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNetCore.Domain
{
    public class Case
    {
        public Case()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string SurgeryName { get; set; }

        public string SurgeryNickname { get; set; }

        public Clinic Clinic { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Notes { get; set; }
    }
}
