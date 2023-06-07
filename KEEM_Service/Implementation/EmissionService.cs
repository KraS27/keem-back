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
        private readonly IEmissionRepository _emissionRepository;
        private readonly IElementService _elementService;

        public EmissionService(IEmissionRepository emissionRepository, IElementService elementService)
        {
            _emissionRepository = emissionRepository;
            _elementService = elementService;
        }

        public async Task<BaseResponse<bool>> AddEmissionsToPoi(List<CreatingEmissionDTO> emissionDTO)
        {
            try
            {
                var emissions = emissionDTO.Select(e => new Emission
                {
                    IdElement = _elementService.GetElementByName(e.ElementName).Result.Id,
                    IdEnvironment = e.IdEnvironment,
                    IdPoi = e.IdPoi,
                    Day = e.Day,
                    Month = e.Month,
                    Year = e.Year,
                    Measure = e.Measure,
                    ValueAvg = e.ValueAvg,
                    ValueMax = e.ValueMax,
                }).ToList();

                await _emissionRepository.CreateRange(emissions);

                return new BaseResponse<bool> { Data= true };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool> { Data = false, Description = $"[AddEmissionToMarker]: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<bool>> AddEmissionToPoi(CreatingEmissionDTO emissionDTO)
        {
            try
            {              
                await _emissionRepository.Create(new Emission
                {
                    IdElement = _elementService.GetElementByName(emissionDTO.ElementName).Result.Id,
                    IdEnvironment = emissionDTO.IdEnvironment,
                    IdPoi = emissionDTO.IdPoi,
                    Day = emissionDTO.Day,
                    Month = emissionDTO.Month,
                    Year = emissionDTO.Year,
                    Measure = emissionDTO.Measure,
                    ValueAvg = emissionDTO.ValueAvg,
                    ValueMax = emissionDTO.ValueMax,                  
                });

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
                        Measure = e.Measure,  
                        ElementName = e.Element.Name
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
