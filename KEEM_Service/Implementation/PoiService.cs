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
       
        public PoiService(IBaseRepository<Poi> poiRepository, IBaseRepository<Gdk> gdkRepository)
        {
            _poiRepository = poiRepository;           
        }

        public async Task<BaseResponse<IEnumerable<PoiDTO>>> GetAllPois(int idEnvironment)
        {
            try
            {               
                var pois = await _poiRepository.GetAll()
                    .Include(poi => poi.TypeOfObject)
                    .Where(p => p.Emissions.Any(e => e.IdEnvironment == idEnvironment))
                    .Select(poi => new PoiDTO
                    {
                        Id = poi.Id,
                        Latitude = poi.Latitude,
                        Longitude = poi.Longitude,
                        Description = poi.Description,
                        NameObject = poi.NameObject,
                        TypeName = poi.TypeOfObject.Name,
                        Emissions = poi.Emissions,
                    }).ToListAsync();

                foreach (var poi in pois)
                {
                    poi.Emissions = poi.Emissions.GroupBy(e => new { e.Year, e.Month, e.Day })                    
                        .First()
                        .ToList();
                }

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
