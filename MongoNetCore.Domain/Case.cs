using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Case : AuditableEntity
    {
        public Case()
        {
        }

        public string Title { get; set; }

        public string Nickname { get; set; }

        public string Notes { get; set; }

        public string ClinicId { get; set; }

        public string ClinicName { get; set; }

        public string ClinicPhoneNumber { get; set; }

        public string ClinicFaxNumber { get; set; }

        public string SurgeonId { get; set; }

        public string SurgeonName { get; set; }

        public string SchedulerId { get; set; }

        public string SchedulerName { get; set; }

        public List<Attendee> Attendees { get; set; }

        public List<Procedure> Procedures { get; set; } // Case Mappings

        public List<Task> Tasks { get; set; }

        public List<Test> Tests { get; set; }
    }
}
