using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KEEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(string userName, string password, HttpContext context)
        {
            var response = await _authService.Login(userName, password, context);
            return new ObjectResult(response);
        }
    }
}
