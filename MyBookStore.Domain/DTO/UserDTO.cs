namespace MyBookStore.Domain.DTO
{
    /**
     * author: xiaotian li
     * plain object
     */
    public class UserDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(string userId, string name, string password, int role)
        {
            UserId = userId;
            Name = name;
            Password = password;
            Role = role;
        }
    }
}