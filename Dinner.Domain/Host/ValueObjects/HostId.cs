using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public class HostId :ValueObject
    {
        public Guid Value { get; private set; }
        public HostId(Guid guid)
        {
            Value =  guid;
        }
        public static HostId Create (Guid hostId)
        {
            return new HostId (hostId);
        }
        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
