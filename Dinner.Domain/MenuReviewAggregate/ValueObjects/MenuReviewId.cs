using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set; }
        public MenuReviewId(Guid guid)
        {
            Value = guid;
        }
        protected MenuReviewId()
        {
            
        }
        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
