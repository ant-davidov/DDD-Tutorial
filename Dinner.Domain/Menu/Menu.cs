using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu
{
    public class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new List<MenuSection>();
        private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();
        private readonly List<MenuReviewId> _menuReviewId = new List<MenuReviewId>();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AveregeRating AverageRating {  get; private set; }
        public HostId HostId { get; private set; }
        public IReadOnlyCollection<MenuSection> Sections =>  _sections.AsReadOnly();
        public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyCollection<MenuReviewId> MenuReviewId => _menuReviewId.AsReadOnly();
        public DateTime CreateDateTime { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

        protected Menu() { }
        private Menu(
            MenuId menuId, 
            string name, 
            string description, 
            HostId hostId,
            List<MenuSection> sections,
            DateTime createDateTime, 
            DateTime updateDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
        }
        public static Menu Create (string name, string description, HostId hostId, List<MenuSection> sections)
        {
            return new(MenuId.CreateUnique(), 
                name, 
                description, 
                hostId, 
                sections,
                DateTime.UtcNow, 
                DateTime.UtcNow);
        }

    }
}
