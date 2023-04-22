using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Responses;

namespace KEEM_Service.Interfaces
{
    public interface IPoiService
    {
        Task<BaseResponse<IEnumerable<PoiDTO>>> GetAllPois(int idEnvironment);
    }
}
