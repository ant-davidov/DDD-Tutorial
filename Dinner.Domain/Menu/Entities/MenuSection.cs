using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

        protected MenuSection() { }
        public MenuSection(MenuSectionId menuSectionId, 
            string name, 
            string description,
            List<MenuItem> items) : base(menuSectionId) 
        {
            Name = name;
            Description = description;
            _items = items;

        }
        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new MenuSection(MenuSectionId.CreateUnique(), 
                name, 
                description,
                items);    
        }
        
    }
}
