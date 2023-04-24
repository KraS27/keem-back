using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Service.Implementation
{
    public class EmissionService : IEmissionService
    {
        private readonly IBaseRepository<Emission> _emissionRepository;

        public EmissionService(IBaseRepository<Emission> emissionRepository)
        {
            _emissionRepository = emissionRepository;
        }

        public async Task<BaseResponse<IEnumerable<Emission>>> GetAllEmissions()
        {            
            try
            {               
                var emissions = await _emissionRepository.GetAll().ToListAsync();

                if(emissions.Count > 0)
                {
                    return new BaseResponse<IEnumerable<Emission>>
                    {
                        Data = null,
                        Description = "[GetAllEmissions]: Emissions not found"
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<Emission>>
                    {
                        Data = emissions,
                    };
                }
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Emission>>
                {
                    Data = null,
                    Description = $"[GetAllEmissions]: {ex.Message}"
                };

            }
        }
    }
}
