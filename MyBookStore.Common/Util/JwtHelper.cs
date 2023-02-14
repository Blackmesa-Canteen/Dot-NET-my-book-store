using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBookStore.Domain.DTO;

namespace MyBookStore.Common.Util
{
    /**
     * helper class for JWT token
     *
     * author: xiaotian li;
     * author: https://www.codemag.com/Article/2105051/Implementing-JWT-Authentication-in-ASP.NET-Core-5
     */
    public static class JwtHelper
    {
        private const double EXPIRY_DURATION_MINUTES = 30;
        
        public static string BuildToken(string key, string issuer, string audience, UserDTO user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Role, Convert.ToString(user.Role)),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public static UserDTO DecodeToken(string key, string issuer, string audience, string token)
        {
            UserDTO res = new UserDTO();
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);

                var jwtSecurityToken = (JwtSecurityToken) validatedToken;
                string userId = jwtSecurityToken.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
                string name = jwtSecurityToken.Claims.First(i => i.Type == ClaimTypes.Name).Value;
                int role = int.Parse(jwtSecurityToken.Claims.First(i => i.Type == ClaimTypes.Role).Value);

                res.UserId = userId;
                res.Name = name;
                res.Role = role;
            }
            catch (Exception e)
            {
                // ignored
            }

            return res;
        }


        public static bool IsTokenValid(string key, string issuer, string audience,  string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = mySecurityKey,
                    }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}