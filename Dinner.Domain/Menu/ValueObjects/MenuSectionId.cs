using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        public MenuSectionId(Guid guid)
        {
            Value = guid;
        }
        protected MenuSectionId()
        {
            
        }
        public static MenuSectionId Create (Guid guid) 
        {
            return new MenuSectionId (guid); 
        }
        public static MenuSectionId CreateUnique()
        {
            return new MenuSectionId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
