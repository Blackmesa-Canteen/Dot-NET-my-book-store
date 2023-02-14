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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IUserService userService)
        {
            _logger = logger;
            this._bookService = bookService;
            this._userService = userService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> BookStore()
        {
            R result = await _bookService.GetAllBooks();
            
            return View(result.GetData());
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

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

        [Authorize]
        public async Task<IActionResult> Reserve(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            string userId = "abc";

            R result = await _bookService.ReserveBook(id, userId);
            return handleServiceResultOnBookStore(result);
        }

        [Authorize]
        public async Task<IActionResult> Return(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            string userId = this.User.Claims.First(i =>i.Type == ClaimTypes.NameIdentifier).Value;

            R result = await _bookService.ReturnBook(id, userId);
            return handleServiceResultOnBookStore(result);
        }

        // public IActionResult Notice(R serviceResult)
        // {
        //     return View(serviceResult);
        // }

        /**
         * Handles service results at the bookstore page, then refresh the page
         */
        private IActionResult handleServiceResultOnBookStore(R serviceResult)
        {
            if (serviceResult.GetCode() != ExceptionEnum.OK.GetStatusCode())
            {
                
                string errorString = $"[{serviceResult.GetMessage()}]: {(string) serviceResult.GetData()}";
                ModelState.AddModelError(string.Empty, errorString);
            }

            return RedirectToAction(nameof(BookStore));
        }
    }
    
}