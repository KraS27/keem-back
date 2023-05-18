using KEEM_DAL.Implementation;
using KEEM_Domain.Entities.DTO;
using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KEEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoiController : ControllerBase
    {
        private readonly IPoiService _poiService;

        public PoiController(IPoiService poiService)
        {
            _poiService = poiService;
        }

        [HttpGet("/pois")]
        public async Task<IActionResult> GetAllPoisAsync(int idEnvironment)
        {
            var response = await _poiService.GetAllPois(idEnvironment);
            return new ObjectResult(response);
        }

        [HttpPost("/pois")]
        public async Task<IActionResult> AddPoi(PoiDTO poiDTO)
        {
            var response = await _poiService.AddPoi(poiDTO);
            return new ObjectResult(response);
        }
    }
}
