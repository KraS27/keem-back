using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KEEM_Service.Implementation
{
    public class EmissionService : IEmissionService
    {
        private readonly IBaseRepository<Emission> _emissionRepository;

        public EmissionService(IBaseRepository<Emission> emissionRepository)
        {
            _emissionRepository = emissionRepository;
        }

        public async Task<BaseResponse<bool>> AddEmissionToMarker(EmissionDTO emissionDTO)
        {
            try
            {
                return new BaseResponse<bool> { Data= true };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool> { Data= false, Description = $"[AddEmissionToMarker]: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<IEnumerable<EmissionDTO>>> GetAllEmissions(int count)
        {            
            try
            {
                var emissions = await _emissionRepository.GetAll()
                    .Take(count)
                    .Select(e => new EmissionDTO
                    {
                        Id = e.Id,
                        Day = e.Day,
                        Month = e.Month,
                        Year = e.Year,
                        ValueAvg= e.ValueAvg,
                        ValueMax= e.ValueMax,
                        Measure = e.Measure
                    })
                    .ToListAsync();

                if(emissions.Count > 0)
                {
                    return new BaseResponse<IEnumerable<EmissionDTO>>
                    {
                        Data = emissions,
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<EmissionDTO>>
                    {                     
                        Description = "[GetAllEmissions]: Emissions not found"
                    };                   
                }
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<EmissionDTO>>
                {                
                    Description = $"[GetAllEmissions]: {ex.Message}"
                };

            }
        }

        public async Task<BaseResponse<IEnumerable<EmissionDTO>>> GetEmissionsByPoi(int idPoi)
        {
            try
            {
                var emissions = await _emissionRepository.GetAll()   
                    .Include(e => e.Element)
                    .Where(e => e.IdPoi == idPoi)                   
                    .Select(e => new EmissionDTO
                    {
                        Id = e.Id,
                        Day = e.Day,
                        Month = e.Month,
                        Year = e.Year,
                        ValueAvg = Math.Round(e.ValueAvg, 4),
                        ValueMax = Math.Round(e.ValueMax, 4),
                        Measure = e.Measure,
                        ElementName = e.Element.Name
                    })
                    .ToListAsync();

                if (emissions.Count > 0)
                {
                    return new BaseResponse<IEnumerable<EmissionDTO>>
                    {
                        Data = emissions,
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<EmissionDTO>>
                    {                      
                        Description = "[GetAllEmissions]: Emissions not found"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<EmissionDTO>>
                {                    
                    Description = $"[GetAllEmissions]: {ex.Message}"
                };

            }
        }
    }
}
