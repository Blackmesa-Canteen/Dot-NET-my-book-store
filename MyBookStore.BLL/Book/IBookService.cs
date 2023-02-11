using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IEnumerable<BookDTO>> GetAllBooks();

        /**
         * Reserve a book with bookId and userid.
         * If successful reserved a book, returns true.
         */
        Task<bool> ReserveBook(string bookId, string userId);
        
        /**
         * Return a book with bookId and userid.
         * If successful reserved a book, returns true.
         */
        Task<bool> ReturnBook(string bookId, string userId);
    }
}