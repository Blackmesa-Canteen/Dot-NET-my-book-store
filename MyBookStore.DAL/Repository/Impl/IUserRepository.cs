using System.Threading.Tasks;
using MyBookStore.Domain;

namespace MyBookStore.DAL.Repository.Impl
{
    /**
     * author: xiaotian li
     */
    public interface IUserRepository : IBaseRepository<User>
    {
        /**
         * Find user by user uuid
         */
        Task<User> FindUserByUserId(string userId);
        
    }
}