using KEEM_Domain.Entities.Models;
using KEEM_Domain.Entities.Responses;


namespace KEEM_Service.Interfaces
{
    public interface IEmissionService
    {
        Task<BaseResponse<IEnumerable<Emission>>> GetAllEmissions();
    }
}
