using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Task : AuditableEntity
    {
        public Task()
        {
        }

        public string Content { get; set; }

        public bool Completed { get; set; } = false;

        public bool Required { get; set; } = false;
    }
}
