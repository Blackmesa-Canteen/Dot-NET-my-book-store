using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBookStore.BLL.User;

namespace MyBookStore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public RegisterController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
    }
}