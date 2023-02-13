using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.BLL.Book;
using MyBookStore.Common.constant;
using MyBookStore.Domain.DTO;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("api/v1/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookService.GetAllBooks();

            if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
            {
                IEnumerable<BookDTO> resList = (IEnumerable<BookDTO>)result.GetData();
                return Ok(
                    new
                    {
                        data = resList
                    }
                );
            }
            else
            {
                // if failed
                return new ObjectResult(result.GetMessage())
                {
                    StatusCode = result.GetCode()
                };
            }
        }
    }
}