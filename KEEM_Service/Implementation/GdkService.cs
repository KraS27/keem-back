using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DTO;
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
    public class GdkService : IGdkService
    {
        private readonly IBaseRepository<GdkDTO> _gdkRepository;

        public GdkService(IBaseRepository<GdkDTO> gdkRepository)
        {
            _gdkRepository = gdkRepository;
        }

        public async Task<BaseResponse<IEnumerable<GdkDTO>>> GetAllGdk(int idEnvironment)
        {
            try
            {
                var gdks = await _gdkRepository.GetAll().ToListAsync();

                if (gdks.Count != 0)
                    return new BaseResponse<IEnumerable<GdkDTO>> { Data = gdks };
                else
                    return new BaseResponse<IEnumerable<GdkDTO>> { Description = "Gdk not found" };                                 
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<GdkDTO>>
                {
                    Description = $"[GetAllGdk] : {ex.Message}"
                };
            }
        }
    }
}
