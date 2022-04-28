namespace MongoNetCore.Domain.Shared
{
    public class ContactInfo : AddressInfo
    {
        public ContactInfo()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string MobileNumber { get; set; }

        public string OfficeNumber { get; set; }
    }
}
