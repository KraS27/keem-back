using KEEM_Domain.Entities.Models;

namespace KEEM_Service.Interfaces
{
    public interface IElementService
    {
        Task<Element> GetElementByName(string name);
    }
}
