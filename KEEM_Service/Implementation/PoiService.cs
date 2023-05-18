using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;
using KEEM_Domain.Extensions;
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

        public async Task<BaseResponse<bool>> AddPoi(PoiDTO poiDTO)
        {
            try
            {
                await _poiRepository.Create(new Poi
                {
                    IdOfUser = poiDTO.IdOfUser,
                    Type = 273,
                    OwnerType = poiDTO.OwnerType,
                    Latitude = poiDTO.Latitude,
                    Longitude = poiDTO.Longitude,
                    Description = poiDTO.Description,
                    NameObject = poiDTO.NameObject,
                });

                return new BaseResponse<bool> { Data = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Data = false, Description = $"[AddPoi]: {ex.Message}" };
            }
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

                var mapPoiToPoiDto =
                    pois.Select(poi => new PoiDTO
                    {
                        Id = poi.Id,
                        IdOfUser = poi.IdOfUser,
                        OwnerType = poi.OwnerType,
                        Description = poi.Description,
                        Latitude = poi.Latitude,
                        Longitude = poi.Longitude,
                        TypeName = poi.TypeOfObject.Name,
                        NameObject = poi.NameObject,
                        isPolluted = CheckIsPoluted(poi.Emissions)
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

        private int CheckIsPoluted(List<Emission> emissions)
        {
            var gdks = _gdkService.GetAllGdk().Result.Data;

            if(emissions.Count != 0) 
            {
                return emissions.GroupBy(e => new { e.Year, e.Month, e.Day })
                    .First()
                    .ToList()
                    .AnyReturnInt(e =>
                    {
                        var elementGdk = gdks.FirstOrDefault(g => g.Id == e.IdElement);

                        if (elementGdk == null)
                            return -1;
                        else if (e.ValueAvg >= elementGdk.MpcAverage_D)
                            return 1;
                        else
                            return 0;
                    });
            }
            else { return -1; }
        }
    }
}
