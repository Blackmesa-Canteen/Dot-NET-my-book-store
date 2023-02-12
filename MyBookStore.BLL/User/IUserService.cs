using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.User
{
    /**
     * author: xiaotian li
     */
    public interface IUserService
    {
        /**
         * Register a user. If successful, returns R with ok status code
         */
        R RegisterUser(UserDTO userDto);
        
        /**
         * Login a user with credential,
         * Returns a valid token if successful, otherwise, returns R with err info.
         */
        R LoginUser(UserDTO userDto);
        
        /**
         * logout a user by deprecate token. If successful, returns R with ok status code.
         */
        R LogoutUser(UserDTO userDto);

        /**
         * Get user information based on userId. If successful, returns R with UserDTO.
         * otherwise, returns null.
         */
        R GetUserInfoWithId(string userId);
    }
}