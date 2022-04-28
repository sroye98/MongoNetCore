using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Attendee : AuditableEntity
    {
        public Attendee()
        {
        }

        public ContactInfo ContactInfo { get; set; }

        // Case Assistant, Vendor, Residents, etc.
        public string Type { get; set; }
    }
}
