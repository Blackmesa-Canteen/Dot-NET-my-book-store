using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBookStore.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var userName = Request.Form["name"];
            var password = Request.Form["password"];
            throw new NotImplementedException();
        }
    }
}