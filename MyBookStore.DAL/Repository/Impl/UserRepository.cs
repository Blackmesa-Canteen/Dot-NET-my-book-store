using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL.DataSource;
using MyBookStore.Domain;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Repository.Impl
{
    public class UserRepository : AbstractBaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContextManager dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindUserByUserId(string userId)
        {
            return await _dbContext.UserSet
                .FirstOrDefaultAsync(user => user.UserId.Equals(userId));
        }
    }
}