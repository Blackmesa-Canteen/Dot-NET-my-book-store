using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyBookStore.DAL.Repository;
using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.Book.Impl
{
    /**
     * author: xiaotian li
     */
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private IMediator _mediator;
        private readonly IMapper _mapper;
        
        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            IEnumerable<Domain.Entity.Book> books = await _bookRepository.FindAll();
            IEnumerable<BookDTO> res = new List<BookDTO>();
            
            foreach (Domain.Entity.Book book in books)
            {
                BookDTO bookDto = new BookDTO(
                    book.BookId,
                    book.Name,
                    book.Description,
                    book.CoverImgUrl,
                    book.UserId
                );

                res.Append(bookDto);
            }

            return res;
        }
        
        public async Task<bool> ReserveBook(string bookId, string userId)
        {
            Domain.Entity.Book theBook = await _bookRepository.FindBookByBookId(bookId);
            if (theBook == null)
            {
                return false;
            }
            else
            {
                if (theBook.UserId != null)
                {
                    // if the book has been reserved
                    return false;
                }
                else
                {
                    // reserve the book and update db
                    theBook.UserId = userId;
                    
                    // update the book info
                    var command = 
                }
            }

            return true;
        }

        public Task<bool> ReturnBook(string bookId, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}