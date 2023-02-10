using System;

namespace MyBookStore.Domain.Entity
{
    /**
     * Author: Xiaotian Li
     */
    public class User : AbstractBaseEntity
    {

        public User() : base()
        {
        }

        public User(string userId, string name, string password, int role) : base()
        {
            UserId = userId;
            Name = name;
            Password = password;
            Role = role;
        }
        
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}