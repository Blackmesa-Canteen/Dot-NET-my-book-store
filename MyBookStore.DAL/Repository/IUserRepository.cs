using System.Threading.Tasks;
using MyBookStore.Domain;
using MyBookStore.Domain.Entity;

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