using System.Threading.Tasks;
using MyBookStore.Common.Entity;
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
        Task<R> RegisterUser(UserDTO userDto);
        
        /**
         * Login a user with credential,
         * Returns Ok with token if login success, otherwise, returns R with err info.
         */
        Task<R> LoginUser(UserDTO userDto);
        
        /**
         * logout a user by deprecate token. If successful, returns R with ok status code.
         */
        Task<R> LogoutUser(UserDTO userDto);

        /**
         * Get user information based on userId. If successful, returns R with User information.
         * otherwise, returns null.
         */
        Task<R> GetUserInfoWithId(string userId);
    }
}