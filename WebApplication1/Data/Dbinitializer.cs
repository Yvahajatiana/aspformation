using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class Dbinitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            IEnumerable<User> UserList = new List<User>
            {
                new User { FirstName = "First Name 0", LastName = "Last Name 0", Password = "Password 0"},
                new User { FirstName = "First Name 1", LastName = "Last Name 1", Password = "Password 1"},
                new User { FirstName = "First Name 2", LastName = "Last Name 2", Password = "Password 2"},
                new User { FirstName = "First Name 3", LastName = "Last Name 3", Password = "Password 3"},
                new User { FirstName = "First Name 4", LastName = "Last Name 4", Password = "Password 4"}
            };

            context.Users.AddRange(UserList);

            context.SaveChanges();

        }
    }
}
