using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        private User(UserId userId, string firstName, string lastName, string email, string password) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public static User Create(string fisrtName, string lastName, string email, string password)
        {
            return new User(UserId.CreateUnique(), fisrtName, lastName, email, password);
        }

    }
}
