using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }
        public MenuItemId(Guid guid)
        {
            Value = guid;
        }
        protected MenuItemId()
        {
            
        }
        public static MenuItemId Create(Guid guid)
        { 
            return new MenuItemId(guid); 
        }    
        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
