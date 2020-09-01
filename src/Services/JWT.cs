namespace SEMES.Services
{
    class JWT{

        private string mySecret;
        private string myIssuer;
        private string myAudience;

        public JWT(){
            myAudience = "";
            myIssuer = "";
            myAudience = "";
        }
        public string GenerateJSONWebToken(UserModel userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecret));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
            
            var claims = new[] {    
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.username),    
                new Claim(JwtRegisteredClaimNames.Email, userInfo.email),    
                new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),    
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())    
            };    
            
            var token = new JwtSecurityToken(myIssuer,    
                myAudience,    
                claims,    
                // expires: DateTime.Now.AddMinutes(120),    
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