using System;
using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Location : BaseEntity
    {
        public Location()
        {
        }

        public AddressInfo AddressInfo { get; set; }

        public List<ContactInfo> Contacts { get; set; }

        public string Name { get; set; }

        public string Timezone { get; set; }

        public List<OperatingHour> OperatingHours { get; set; }
    }
}
