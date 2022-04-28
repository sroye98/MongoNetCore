using System.Collections.Generic;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Procedure : BaseEntity
    {
        public Procedure()
        {
        }

        public bool AssistantRequired { get; set; }

        public string Category { get; set; }

        public string SurgeryNickname { get; set; }

        public string CPT { get; set; }

        public string ICD { get; set; }

        public string SurgeryTitle { get; set; }

        public string SpecialEquipment { get; set; }

        public double? Duration { get; set; }

        public string Blood { get; set; }

        public string Admission { get; set; }

        public string Restrictions { get; set; }

        public string Meds { get; set; }

        public string DME { get; set; }

        public string NurseInstructions { get; set; }

        public string Position { get; set; }

        public string Medications { get; set; }

        public string Diet { get; set; }

        public string DressingAndWoundCare { get; set; }

        public string Swelling { get; set; }

        public string Activity { get; set; }

        public string Exercise { get; set; }

        public string TimeOff { get; set; }

        public string WorkSchool { get; set; }

        public string FU { get; set; }

        public string FollowUpAppointment { get; set; }

        public string EmergencyCare { get; set; }

        public string Url { get; set; }

        public string ProcedureEducationUrl { get; set; }

        public string Outcome { get; set; }

        public string Recovery { get; set; }

        public string Risks { get; set; }

        public string Prep { get; set; }

        public string Dressing { get; set; }

        public string Closure { get; set; }

        public string Details { get; set; }

        public List<Diagnosis> Diangoses { get; set; }

        public List<Vendor> Vendors { get; set; }

        public List<Anesthesia> Anesthesia { get; set; }

        public List<Medication> PostOpMedications { get; set; }

        public List<Restriction> PostOpRestrictions { get; set; }

        public List<Test> Tests { get; set; }

        public List<Task> Tasks { get; set; }

        public List<string> Tags { get; set; }
    }
}
