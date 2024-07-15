using FinTransactAPI.Model;
using FinTransactAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTransactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly LoginService _loginService; 
        public UserAuthenticationController(TokenService tokenService, LoginService loginService)
        {
            _tokenService = tokenService;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserLogin model)
        {
            UserAuthentication userAuthentication = _loginService.IsUserAuthenticated(model.Username, model.Password);
            if (userAuthentication.UserId > 0)
            {
                var token = _tokenService.GenerateToken(model.Username);
                return Ok(new { Token = token, UserId = userAuthentication.UserId });
            }

            return Unauthorized();
        }
    }
}
