using System;
using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Surgeon : AuditableEntity
    {
        public Surgeon()
        {
        }

        public ContactInfo ContactInfo { get; set; }

        public List<Attendee> Attendees { get; set; }

        public Practice PracticeInfo { get; set; }

        public List<Location> Locations { get; set; }

        public List<Clinic> Clinics { get; set; }
    }
}
