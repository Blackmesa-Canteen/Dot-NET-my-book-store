using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.User
{
    /**
     * author: xiaotian li
     */
    public interface IUserService
    {
        /**
         * Register a user. If successful, returns true
         */
        bool RegisterUser(UserDTO userDto);
        
        /**
         * Login a user with credential,
         * Returns a valid token if successful, otherwise, returns null.
         */
        string LoginUser(UserDTO userDto);
        
        /**
         * logout a user by deprecate token. If successful, returns true.
         */
        bool LogoutUser(UserDTO userDto);

        /**
         * Get user information based on userId. If successful, returns the UserDTO.
         * otherwise, returns null.
         */
        UserDTO GetUserInfoWithId(string userId);
    }
}