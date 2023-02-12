using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookStore.Common.Entity;
using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.Book
{
    /**
     * author: xiaotian li
     */
    public interface IBookService
    {
        /**
         * Get all book information from db.
         */
        Task<R> GetAllBooks();

        /**
         * Reserve a book with bookId and userid.
         * If successful reserved a book, returns R with status ok.
         */
        Task<R> ReserveBook(string bookId, string userId);

        /**
         * Return a book with bookId and userId
         */
        Task<R> ReturnBook(string bookId, string userId);
    }
}