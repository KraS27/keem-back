using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Responses;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KEEM_Service.Implementation
{
    public class PoiService : IPoiService
    {
        private readonly IBaseRepository<Poi> _poiRepository;

        public PoiService(IBaseRepository<Poi> poiRepository)
        {
            _poiRepository = poiRepository;
        }

        public async Task<BaseResponse<IEnumerable<PoiDTO>>> GetAllPois()
        {
            try
            {
                var pois = await _poiRepository.GetAll().Select(poi => new PoiDTO
                {
                    Id = poi.Id,
                    Latitude = poi.Latitude,
                    Longitude = poi.Longitude,
                    NameObject = poi.NameObject
                }).ToListAsync();

                if (pois.Count != 0)
                {
                    return new BaseResponse<IEnumerable<PoiDTO>>
                    {
                        Data = pois
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<PoiDTO>>
                    {
                        Data = null,
                        Description = "Pois not found"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PoiDTO>>
                {
                    Data = null,
                    Description = $"[GetAll]: {ex.Message}"
                };
            }
        }
    }
}
