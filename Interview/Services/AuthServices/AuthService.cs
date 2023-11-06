using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Interview;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ToTo.Application.Services.AuthServices
{
    public class AuthService 
    {
        
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        public AuthService( IConfiguration configuration , ILogger<AuthService> logger)
        {
   
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<string> GenerateSingleAccessToken(AuthProperties authProperties)
        {
            var securityKey = _configuration["JwtToken:SecretKey"];
            if (securityKey == null)
            {
                var exception = new ArgumentNullException("configuration file not accessible");
                _logger.LogCritical(exception , "can not read configuration file: securityKey");
                throw exception;
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["JwtToken:Issuer"];
            var audience = _configuration["JwtToken:Audience"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtToken:TokenExpiry"]));
            

            var claims = new List<Claim>();
            //{
            //    //new Claim("pantaa", authProperties.UserName),
            //    //new Claim(JwtClaims.RoleId, authProperties.RoleId.ToString()!),
            //    //new Claim(JwtClaims.RoleName, authProperties.RoleName),
            //};
            var token = new JwtSecurityToken(issuer,
                audience,
                expires: jwtValidity,
                claims: claims,
                signingCredentials: creds);
 
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }
    }
}
