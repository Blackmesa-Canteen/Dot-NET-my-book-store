using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.BLL.User;
using MyBookStore.Common.constant;
using MyBookStore.Common.Entity;
using MyBookStore.Domain.DTO;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetAuthToken(string userId, string pwd)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(pwd))
            {
                UserDTO userDto = new UserDTO();
                userDto.UserId = userId;
                userDto.Password = pwd;
                R result = await _userService.LoginUser(userDto);
                
                if (result.GetCode() == ExceptionEnum.OK.GetStatusCode())
                {
                    // if passed login
                    string tokenString = (string) result.GetData();
                    return Ok(
                        new
                        {
                            token = tokenString

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
            else
            {
                return BadRequest(
                    new { message = ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT.GetString() }
                );
            }
        }
    }
}