using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNetCore.Domain
{
    public class Clinic
    {
        public Clinic()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
