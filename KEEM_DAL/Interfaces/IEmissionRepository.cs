using KEEM_Domain.Entities.DTO;
using KEEM_Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_DAL.Interfaces
{
    public interface IEmissionRepository : IBaseRepository<Emission>
    {
        Task CreateRange(IEnumerable<Emission> entities);
    }
}
