using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuberDinner.Domain.Menu.ValueObjects
{
    public class MenuId : ValueObject
    {

        public Guid Value { get; private set; }
        public MenuId(Guid guid)
        {
            Value = guid;
        }
       protected MenuId()
        {
            
        }
        public static MenuId Create(Guid guid)
        {
            return new MenuId(guid);    
        }
        public static MenuId CreateUnique()
        {
            return new MenuId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
