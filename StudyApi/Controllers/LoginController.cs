using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudyApi.Account;
using StudyApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StudyApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;

        public LoginController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> Login(LoginModel loginModel)
        {
            var exist = await _authenticateService.UserExists(loginModel.Username);
            if (!exist)
            {
                return Unauthorized("User do not exist.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Username, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Invalid credentials. Enter with your username and password.");
            }

            var user = await _authenticateService.GetUserByUsername(loginModel.Username);

            var token = _authenticateService.GenerateToken(user.Id, user.Username);

            return new UserToken
            {
                Token = token,
            };
        }

    }
}