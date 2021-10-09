using System;
using System.Collections.Generic;
using System.Linq;
using DNP1Assignment1.Models;


namespace DNP1Assignment1.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "lokkazy", Password = "oguricap", SecurityLevel = 1
                },
                new User
                {
                    UserName = "Inui", Password = "toko", SecurityLevel = 2
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}