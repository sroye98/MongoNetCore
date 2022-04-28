using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Submission : AuditableEntity
    {
        public Submission()
        {
        }

        public string Content { get; set; }
    }
}
