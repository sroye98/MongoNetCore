using System;
using MongoNetCore.Domain.Shared;

namespace MongoNetCore.Domain
{
    public class OperatingHour : BaseEntity
    {
        public OperatingHour()
        {
        }

        public string Day { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }
    }
}
