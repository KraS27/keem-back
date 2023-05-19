using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Responses;


namespace KEEM_Service.Interfaces
{
    public interface IEmissionService
    {
        Task<BaseResponse<IEnumerable<EmissionDTO>>> GetAllEmissions(int count = 300);

        Task<BaseResponse<IEnumerable<EmissionDTO>>> GetEmissionsByPoi(int idPoi);

        Task<BaseResponse<bool>> AddEmissionToPoi(CreatingEmissionDTO emissionDTO);
    }
}
