using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Domain.VO
{
    public class UserRegisterVo
    {
        public UserRegisterVo()
        {
        }

        public UserRegisterVo(string userId, string name, string password)
        {
            UserId = userId;
            Name = name;
            Password = password;
        }

        [Required]
        public string UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}