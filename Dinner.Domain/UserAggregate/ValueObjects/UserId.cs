using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.User.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; private set; }
        public UserId(Guid guid)
        {
            Value = guid;
        }
        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
