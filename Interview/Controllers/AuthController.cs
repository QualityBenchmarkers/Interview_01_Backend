using Interview.Database.Configuration.ConfigurationTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToTo.Application.Services.AuthServices;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;
        private LoginCredentialConfiguration _loginConfiguration;

        public AuthController(AuthService authService , IOptions<LoginCredentialConfiguration> loginConfiguration)
        {
            _authService = authService;
            _loginConfiguration = loginConfiguration.Value;

        }



        [HttpPost("Login")]
        public async Task<ActionResult<object>> Login(AuthProperties authInfo)
        {

            if (authInfo.Username != _loginConfiguration.UserName || authInfo.Password != _loginConfiguration.Password)
            {
                return Unauthorized(new
                {
                    message = "نام کاربری یا رمزعبور اشتباه می‌باشد"
                }); 
            }


           string token = await  _authService.GenerateSingleAccessToken(authInfo);



            return new
            {
                token = token,
            };
        }


        
 



    }
}
