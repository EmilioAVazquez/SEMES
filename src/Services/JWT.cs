using SEMES.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Options;

namespace SEMES.Services
{
    class JWT:IJWT{

        private string mySecret;
        private string myIssuer;
        private string myAudience;

        public JWT(JWTOptions options){
            myAudience = options.audience;
            myIssuer = options.issuer;
            mySecret = options.key;
        }
        public string GenerateJSONWebToken(SemesUser user)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecret));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
            
            var claims = new[] {    
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),    
                new Claim(JwtRegisteredClaimNames.Email, user.Email),    
                // new Claim("DateOfJoing", user.DateOfJoing.ToString("yyyy-MM-dd")),    
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())    
            };    
            
            var token = new JwtSecurityToken(
                myIssuer,    
                myAudience,    
                claims,    
                //expires: DateTime.Now.AddMinutes(120),    
                signingCredentials: credentials);    
            
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }

        public bool ValidateJSONWebToken(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = mySecurityKey
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