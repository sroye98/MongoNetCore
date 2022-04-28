using System;
using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Vendor : AuditableEntity
    {
        public Vendor()
        {
        }

        public ContactInfo ContactInfo { get; set; }

        public List<string> Equipment { get; set; }
    }
}
