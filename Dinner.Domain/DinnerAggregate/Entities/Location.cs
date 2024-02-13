using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.Entities
{
    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        private Location(
            string name,
            string description,
            double latitude,
            double longitude)
        {
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location Create(
            string name,
            string description,
            double latitude,
            double longitude)
        {
            return new(
                name,
                description,
                latitude,
                longitude);
        }
    }
}
