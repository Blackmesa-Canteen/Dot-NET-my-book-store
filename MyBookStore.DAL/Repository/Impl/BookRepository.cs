using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL.DataSource;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Repository.Impl
{
    /**
     * author: xiaotian li
     */
    public class BookRepository : AbstractBaseRepository<Book>, IBookRepository
    {
        public BookRepository(DbContextManager dbContext) : base(dbContext)
        {
        }

        public async Task<Book> FindBookByBookId(string bookId)
        {
            return await _dbContext.BookSet
                .FirstOrDefaultAsync(book => book.BookId.Equals(bookId));
        }

        public async Task<Book> FindBookByName(string name)
        {
            return await _dbContext.BookSet
                .FirstOrDefaultAsync(book => book.Name.Equals(name));
        }

        public async Task<IEnumerable<Book>> SearchBooksByName(string name)
        {
            return await _dbContext.BookSet
                .Where(book => EF.Functions.Like(book.Name, $"%{name}%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchBooksByUserId(string userId)
        {
            return await _dbContext.BookSet
                .Where(book => book.UserId != null && book.UserId.Equals(userId))
                .ToListAsync();
        }
    }
}