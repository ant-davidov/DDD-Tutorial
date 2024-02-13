using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public  class Rating : ValueObject
    {
        public double Value { get; private set; }

        private Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateNew(double value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
