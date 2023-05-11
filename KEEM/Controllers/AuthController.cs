using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KEEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var response = await _authService.Login(userName, password, HttpContext);
            return new ObjectResult(response);
        }

        [HttpDelete("/logout")]
        public async Task<IActionResult> LogOut()
        {
            var response = await _authService.LogOut(HttpContext);
            return new ObjectResult(response);
        }
    }
}
