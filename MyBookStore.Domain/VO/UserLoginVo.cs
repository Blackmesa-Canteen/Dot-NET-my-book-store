using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Domain.VO
{
    /**
     * author: xiaotian li
     */
    public class UserLoginVo
    {
        public UserLoginVo()
        {
        }

        public UserLoginVo(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
        
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}