using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KEEM_Service.Implementation
{
    public class PoiService : IPoiService
    {
        private readonly IBaseRepository<Poi> _poiRepository; 
        private readonly IGdkService _gdkService;

        public PoiService(IBaseRepository<Poi> poiRepository, IGdkService gdkService)
        {
            _poiRepository = poiRepository;
            _gdkService = gdkService;
        }

        public async Task<BaseResponse<IEnumerable<PoiDTO>>> GetAllPois(int idEnvironment)
        {
            try
            {               
                var pois = await _poiRepository.GetAll()
                    .Include(poi => poi.TypeOfObject)
                    .Include(poi => poi.Emissions)
                    .Where(p => p.Emissions.Any(e => e.IdEnvironment == idEnvironment))
                    .ToListAsync();

                var gdks = _gdkService.GetAllGdk().Result.Data;
                                                         
                var mapPoiToPoiDto =  pois.Select(poi => new PoiDTO
                                        {
                                            Id = poi.Id,
                                            Description = poi.Description,
                                            Latitude = poi.Latitude,
                                            Longitude = poi.Longitude,
                                            TypeName = poi.TypeOfObject.Name,
                                            NameObject = poi.NameObject,
                                            isPolluted = 
                                            poi.Emissions.GroupBy(e => new { e.Year, e.Month, e.Day })
                                                        .FirstOrDefault()
                                                        .Any(e => e?.ValueAvg >= gdks.FirstOrDefault(g => g.Id == e.IdElement)?.MpcAverage_D)
                                        }).ToList();
                

                if (pois.Count != 0)
                    return new BaseResponse<IEnumerable<PoiDTO>> { Data = mapPoiToPoiDto };
                else
                    return new BaseResponse<IEnumerable<PoiDTO>> { Description = "Pois not found" };
                                  
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PoiDTO>>
                {
                    Description = $"[GetAll]: {ex.Message}"
                };
            }
        }
    }
}
