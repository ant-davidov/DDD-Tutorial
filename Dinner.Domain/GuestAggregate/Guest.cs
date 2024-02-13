using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Guest
{
    public class Guest : AggregateRoot<GuestId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public double AverageRating { get; }
        public UserId UserId { get; }
        private List<DinnerId> _upcomingDinnerIds = new List<DinnerId>();
        private List<DinnerId> _pastDinnerIds = new List<DinnerId>();
        private Guest(GuestId guestId, string firstName, string lastName, string profileImage, double averageRating, UserId userId) : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
        }
        protected Guest()
        {

        }
        public static Guest Create(string firstName, string lastName, string profileImage, double averageRating, UserId userId)
        {
            return new Guest(GuestId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId);
        }
    }
}
