using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);

        Task CreateRange(IEnumerable<T> entities);

        IQueryable<T> GetAll();

        Task Delete(T entity);

        Task Update(T entity);
    }
}
