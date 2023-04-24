using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KEEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmissionController : ControllerBase
    {
        private readonly IEmissionService _emissionService;

        public EmissionController(IEmissionService emissionService)
        {
            _emissionService = emissionService;
        }

        [HttpGet("/emissions")]
        public async Task<IActionResult> GetAllEmissionsAsync()
        {
            var response = await _emissionService.GetAllEmissions();
            return new ObjectResult(response);
        }
    }
}
