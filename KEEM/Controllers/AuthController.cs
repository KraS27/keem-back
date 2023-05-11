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

        [HttpGet("/login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var response = await _authService.Login(userName, password, HttpContext);
            return new ObjectResult(response);
        }
    }
}
