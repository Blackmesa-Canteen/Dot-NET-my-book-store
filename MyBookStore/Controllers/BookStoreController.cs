using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBookStore.BLL.Book;
using MyBookStore.BLL.User;
using MyBookStore.Common.constant;
using MyBookStore.Common.Entity;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.Domain.DTO;
using MyBookStore.Domain.VO;
using MyBookStore.Models;

namespace MyBookStore.Controllers
{
    /**
     * author: xiaotian li
     *
     * main controller
     */
    public class BookStoreController : Controller
    {
        private readonly ILogger<BookStoreController> _logger;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public BookStoreController(ILogger<BookStoreController> logger, IBookService bookService, IUserService userService)
        {
            _logger = logger;
            this._bookService = bookService;
            this._userService = userService;
        }
        
        // public async Task<IActionResult> Index()
        // {
        //     var result = await _bookService.GetAllBooks();
        //     return View(result.GetData());
        // }

        // [HttpPost, ActionName("Reserve")]
        // [Authorize]
        // public async Task<IActionResult> ReserveBook(BookReserveVo bookReserveVo)
        // {
        //     var currentUserInfo = GetCurrentUserInfo();
        //     R result = await _bookService.ReserveBook(bookReserveVo.BookId, currentUserInfo.UserId);
        //     if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
        //     {
        //         return RedirectToAction(nameof(System.Index));
        //     }
        //     else
        //     {
        //         var data = result.GetData();
        //     }
        // }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /**
         * get current login user info
         */
        private UserDTO GetCurrentUserInfo()
        {
            UserDTO userDto = new UserDTO();

            string userId = this.User.Claims.First(i =>i.Type == ClaimTypes.NameIdentifier).Value;

            int role = int.Parse(this.User.Claims.First(i => i.Type == ClaimTypes.Role).Value);
            string name = this.User.Claims.First(i =>i.Type == ClaimTypes.Name).Value;

            userDto.UserId = userId;
            userDto.Name = name;
            userDto.Role = role;

            return userDto;
        }
    }
}