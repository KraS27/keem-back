using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Responses;


namespace KEEM_Service.Interfaces
{
    public interface IGdkService
    {
        Task<BaseResponse<IEnumerable<GdkDTO>>> GetAllGdk();
    }
}
