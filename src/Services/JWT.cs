namespace SEMES.Services
{
    class JWT{

        private string GenerateJSONWebToken(UserModel userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
            
            var claims = new[] {    
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),    
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),    
                new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),    
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())    
            };    
            
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
                _config["Jwt:Issuer"],    
                claims,    
                expires: DateTime.Now.AddMinutes(120),    
                signingCredentials: credentials);    
            
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }

        public bool ValidateJSONWebToken(string token)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://mysite.com";
            var myAudience = "http://myaudience.com";

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