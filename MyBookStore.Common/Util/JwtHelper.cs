using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public static string BuildToken(string key, string issuer, UserDTO user)
        {
            var claims = new[] {    
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Role, Convert.ToString(user.Role)),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));        
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);           
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, 
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);        
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);  
        }
        
        public static bool IsTokenValid(string key, string issuer, string token)
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
                        ValidIssuer = issuer,
                        ValidAudience = issuer, 
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