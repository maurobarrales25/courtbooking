using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courtbookingAPIREST.Domain.Clubs
{
    public readonly record struct ClubScheduleID(Guid Value)
    {
        public static ClubScheduleID New() => new(Guid.NewGuid());
        public static ClubScheduleID From(Guid value) => new(value);

        public override string ToString() => Value.ToString();
    }
}