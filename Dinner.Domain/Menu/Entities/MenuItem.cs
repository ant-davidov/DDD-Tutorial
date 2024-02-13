using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
     public sealed class MenuItem : Entity<MenuItemId>
    {
       
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected MenuItem()
        {
            
        }
        public static MenuItem Create(string name, 
            string description)
        {
            return new(MenuItemId.CreateUnique(), 
                name, 
                description);
        }

        private MenuItem(MenuItemId id, 
            string name, 
            string description) : base(id) 
        {
            Name = name;
            Description = description;
        }
    }
}
