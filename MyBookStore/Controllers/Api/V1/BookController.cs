using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.BLL.Book;
using MyBookStore.Common.constant;
using MyBookStore.Domain.DTO;
using MyBookStore.Domain.VO;

namespace MyBookStore.Controllers.Api.V1
{
    /**
     * RESTful API
     * author: xiaotian li
     */
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("all")]
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
                return StatusCode(result.GetCode(), result.GetMessage());
            }
        }

        [AllowAnonymous]
        [HttpGet("{search}")]
        public async Task<IActionResult> SearchBooksByName(string name)
        {
            var result = await _bookService.SearchBooksByName(name);
            if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
            {
                IEnumerable<BookDTO> resList = (IEnumerable<BookDTO>)result.GetData();
                return Ok(
                    new
                {
                    data = resList
                });
            }
            else
            {
                // if failed
                return StatusCode(result.GetCode(), result.GetMessage());
            }
        }

        [Authorize]
        [HttpPut]
        [Route("reservation")]
        public async Task<IActionResult> ReserveBook([FromBody] BookReserveVo bookReserveVo)
        {
            // get current user id
            string userId = this.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.ReserveBook(bookReserveVo.BookId, userId);

            if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
            {
                return Ok();
            }
            else
            {
                // if failed
                return StatusCode(result.GetCode(), result.GetMessage());
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("reservation")]
        public async Task<IActionResult> ReturnBook([FromBody] BookReserveVo bookReserveVo)
        {
            // get current user id
            string userId = this.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.ReturnBook(bookReserveVo.BookId, userId);

            if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
            {
                return Ok();
            }
            else
            {
                // if failed
                return StatusCode(result.GetCode(), result.GetMessage());
            }
        }
    }
}