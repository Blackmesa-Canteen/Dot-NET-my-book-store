using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.BLL.User;
using MyBookStore.Common.constant;
using MyBookStore.Common.Entity;
using MyBookStore.Domain.DTO;
using MyBookStore.Domain.VO;

namespace MyBookStore.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GetAuthToken([FromBody]UserLoginVo userLoginVo)
        {
            if (!string.IsNullOrEmpty(userLoginVo.UserId) && !string.IsNullOrEmpty(userLoginVo.Password))
            {
                UserDTO userDto = new UserDTO();
                userDto.UserId = userLoginVo.UserId;
                userDto.Password = userLoginVo.Password;
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
        
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterVo userRegisterVo)
        {
            UserDTO userDto = new UserDTO
            {
                UserId = userRegisterVo.UserId,
                Password = userRegisterVo.Password,
                Name = userRegisterVo.Name,
                // default is customer
                Role = MyConstant.CUSTOMER_ROLE
            };

            R result = await _userService.RegisterUser(userDto);
                
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