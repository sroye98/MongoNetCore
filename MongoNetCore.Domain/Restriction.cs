using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Restriction : BaseEntity
    {
        public Restriction()
        {
        }

        public string Name { get; set; }

        public string SeedName { get; set; }

        public bool IsOther => SeedName == "Other";
    }
}
