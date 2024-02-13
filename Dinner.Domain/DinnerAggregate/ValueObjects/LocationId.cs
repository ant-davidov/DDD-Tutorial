using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public class LocationId : ValueObject
    {
        public Guid Value { get; private set; }
        public LocationId(Guid guid)
        {
            Value = guid;
        }
        public static LocationId CreateUnique()
        {
            return new LocationId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
