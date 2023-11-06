using Microsoft.AspNetCore.Mvc;
using ToTo.Application.Services.AuthServices;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;

        }



        [HttpPost("Login")]
        public async Task<ActionResult<object>> Login(AuthProperties authInfo)
        {

            if (authInfo.Username != "pantea" || authInfo.Password != "dev123456789")
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
