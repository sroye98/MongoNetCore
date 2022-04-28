using System;
namespace MongoNetCore.Domain.Shared
{
    public class AddressInfo
    {
        public AddressInfo()
        {
        }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
