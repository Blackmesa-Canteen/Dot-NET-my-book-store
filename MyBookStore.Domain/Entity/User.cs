using System;

namespace MyBookStore.Domain
{
    /**
     * Author: Xiaotian Li
     */
    public class User
    {

        public User()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public User(long id, string userId, string name, string password, int role)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Password = password;
            Role = role;

            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public long Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsRemoved { get; set; }
        
    }
}