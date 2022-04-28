using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Diagnosis : AuditableEntity
    {
        public Diagnosis()
        {
        }

        public string Site { get; set; }

        public string DisplayName { get; set; }

        public string Laterality { get; set; }

        public string Icd { get; set; }

        public string Label { get; set; }

        public string Url { get; set; }

        public bool IsOther { get; set; } = false;
    }
}
