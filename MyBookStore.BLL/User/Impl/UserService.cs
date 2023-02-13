using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using MyBookStore.Common.constant;
using MyBookStore.Common.Entity;
using MyBookStore.Common.Util;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.DAL.Repository;
using MyBookStore.DAL.Repository.Impl;
using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.User.Impl
{
    /**
     * author: xiaotian li
     */
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private IMediator _mediator;

        public UserService()
        {
        }

        public UserService(IUserRepository userRepository, IConfiguration configuration, IMediator mediator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mediator = mediator;
        }

        public async Task<R> RegisterUser(UserDTO userDto)
        {
            // check duplicates
            Domain.Entity.User user = await _userRepository.FindUserByUserId(userDto.UserId);
            if (user != null)
            {
                Console.WriteLine("user {0} already exists", userDto.UserId);
                return R.Error(
                    ExceptionEnum.RESOURCE_DUPLICATED.GetStatusCode(),
                    "Duplicated user"
                );
            }


            // format: salt.hashed
            string cypher = SecurityHelper.HashPassword(userDto.Password);

            var command = new CreateUserCommand();
            command.UserId = userDto.UserId;
            command.Password = cypher;
            command.Name = userDto.Name;
            command.Role = userDto.Role;

            var result = await _mediator.Send(command);
            if (result.HasErrors())
            {
                Console.WriteLine("user {0} CreateUserCommand error", userDto.UserId);
                // error occured during updating command
                return R.Error().SetData(result.GetErrorList());
            }
            else
            {
                return R.Ok();
            }
        }

        public async Task<R> LoginUser(UserDTO userDto)
        {
            // check duplicates
            Domain.Entity.User user = await _userRepository.FindUserByUserId(userDto.UserId);
            if (user == null)
            {
                Console.WriteLine("user {0} not exists", userDto.UserId);
                return R.Error(
                    ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT.GetStatusCode(),
                    ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT.GetString()
                );
            }

            // validate password
            string cypher = user.Password;
            bool isMatched = SecurityHelper.VerifyHashedPassword(userDto.Password, cypher);
            if (!isMatched)
            {
                Console.WriteLine("user {0} password error", userDto.UserId);
                return R.Error(
                    ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT.GetStatusCode(),
                    ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT.GetString()
                );
            }
            else
            {
                UserDTO newUserDto = new UserDTO();
                newUserDto.UserId = user.UserId;
                newUserDto.Name = user.Name;
                newUserDto.Role = user.Role;
                // generate token
                string tokenString = JwtHelper.BuildToken(
                    _configuration["Jwt:Key"], 
                    _configuration["Jwt:Issuer"], 
                    _configuration["Jwt:Audience"], 
                    newUserDto
                    );
                return R.Ok().SetData(tokenString);
            }
        }

        public Task<R> LogoutUser(UserDTO userDto)
        {
            throw new System.NotImplementedException();
        }
        public async Task<R> GetUserInfoWithId(string userId)
        {
            // check duplicates
            Domain.Entity.User user = await _userRepository.FindUserByUserId(userId);
            if (user == null)
            {
                Console.WriteLine("user {0} not exists", userId);
                return R.Error(
                    ExceptionEnum.RESOURCE_NOT_EXIST.GetStatusCode(),
                    "User info not found"
                );
            }
            else
            {
                return R.Ok().SetData(user);
            }
        }
    }
}