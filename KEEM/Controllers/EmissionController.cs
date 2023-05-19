using KEEM_Domain.Entities.DTO;
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
        public async Task<IActionResult> GetAllEmissionsAsync(int count)
        {
            var response = await _emissionService.GetAllEmissions(count);
            return new ObjectResult(response);
        }

        [HttpPost("/emissions")]
        public async Task<IActionResult> AddEmission(EmissionDTO emissionDTO)
        {
            var response = await _emissionService.AddEmissionToPoi(emissionDTO);
            return new ObjectResult(response);
        }

        [HttpGet("/emissions/poi")]
        public async Task<IActionResult> GetEmissionsByPoiAsync(int idPoi)
        {
            var response = await _emissionService.GetEmissionsByPoi(idPoi);
            return new ObjectResult(response);
        }
    }
}
