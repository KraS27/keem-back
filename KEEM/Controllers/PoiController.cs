using KEEM_DAL.Implementation;
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
        public async Task<IActionResult> GetAllPoisAsync()
        {
            var response = await _poiService.GetAllPois();
            return new ObjectResult(response);
        }
    }
}
