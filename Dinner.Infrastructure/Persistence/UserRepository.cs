using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberSinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();
        public void Add(User User)
        {
            _users.Add(User);
        }

        public User? GetUserByEmail(string email)
        {
           return _users.FirstOrDefault(u=> u.Email == email);
        }
    }
}
