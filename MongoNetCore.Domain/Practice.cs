using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Practice : BaseEntity
    {
        public Practice()
        {
        }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public ContactInfo ContactInfo { get; set; }
    }
}
