using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public class GuestId : ValueObject
    {
        public Guid Value { get; private set; }
        public GuestId(Guid guid)
        {
            Value = guid;
        }
        public static GuestId CreateUnique()
        {
            return new GuestId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
