using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookStore.Domain;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Repository
{
    /**
     * author: xiaotian li
     */
    public interface IBookRepository : IBaseRepository<Book>
    {
        /**
         * Find book by book uuid
         */
        Task<Book> FindBookByBookId(string bookId);

        /**
         * Accurately match the name
         */
        Task<Book> FindBookByName(string name);

        /**
         * fuzzy search by book name
         */
        Task<IEnumerable<Book>> SearchBooksByName(string name);

        /**
         * search books by userId
         */
        Task<IEnumerable<Book>> SearchBooksByUserId(string userId);
    }
}