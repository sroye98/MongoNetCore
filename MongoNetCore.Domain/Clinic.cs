using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Clinic : BaseEntity
    {
        public Clinic()
        {
        }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }
    }
}
