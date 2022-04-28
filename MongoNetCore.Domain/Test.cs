using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class Test : BaseEntity
    {
        public Test()
        {
        }

        public string Name { get; set; }
    }
}
