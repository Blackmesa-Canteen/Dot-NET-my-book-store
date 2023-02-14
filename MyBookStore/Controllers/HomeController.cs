using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBookStore.BLL.Book;
using MyBookStore.BLL.User;
using MyBookStore.Common.constant;
using MyBookStore.Common.Entity;
using MyBookStore.Common.Util;
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
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IUserService userService,
            IConfiguration configuration)
        {
            _logger = logger;
            this._bookService = bookService;
            this._userService = userService;
            _configuration = configuration;
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
        
        [HttpPost]
        public async Task<IActionResult> BookStore(string searchString)
        {
            R result = await _bookService.SearchBooksByName(searchString);
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

        public async Task<IActionResult> Reserve(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            // get auth token from cookie
            string? tokenString = Request.Cookies[MyConstant.JWT_COOKIE];
            if (tokenString == null)
            {
                return Unauthorized();
            }

            // get user info out of token string
            UserDTO userInfo = JwtHelper.DecodeToken(
                _configuration[MyConstant.JWT_KEY_CONFIG],
                _configuration[MyConstant.JWT_ISSUER_CONFIG],
                _configuration[MyConstant.JWT_AUDIENCE_CONFIG],
                tokenString);

            string userId = userInfo.UserId;

            R result = await _bookService.ReserveBook(id, userId);
            return handleServiceResultOnBookStore(result);
        }

        public async Task<IActionResult> Return(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            // get auth token from cookie
            string? tokenString = Request.Cookies[MyConstant.JWT_COOKIE];
            if (tokenString == null)
            {
                return Unauthorized();
            }

            // get user info out of token string
            UserDTO userInfo = JwtHelper.DecodeToken(
                _configuration[MyConstant.JWT_KEY_CONFIG],
                _configuration[MyConstant.JWT_ISSUER_CONFIG],
                _configuration[MyConstant.JWT_AUDIENCE_CONFIG],
                tokenString);

            string userId = userInfo.UserId;

            R result = await _bookService.ReturnBook(id, userId);
            return handleServiceResultOnBookStore(result);
        }

        /**
         * Handles service results at the bookstore page, then refresh the page
         */
        private IActionResult handleServiceResultOnBookStore(R serviceResult)
        {
            if (serviceResult.GetCode() != ExceptionEnum.OK.GetStatusCode())
            {
                string errorString = $"[{serviceResult.GetMessage()}]: {(string)serviceResult.GetData()}";
                ModelState.AddModelError(string.Empty, errorString);
                TempData["ErrorMes"] = errorString;
            }

            return RedirectToAction(nameof(BookStore));
        }
    }
}