using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }
        public DinnerId(Guid guid)
        {
            Value = guid;
        }
        protected DinnerId()
        {
            
        }
        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
