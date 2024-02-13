using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Bills.ValueObjects
{
    public class BillId : ValueObject
    {
        public Guid Value { get; private set; }
        public BillId(Guid guid)
        {
            Value = guid;
        }
        public static BillId CreateUnique()
        {
            return new BillId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
