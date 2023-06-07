using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;

namespace KEEM_DAL.Implementation
{
    public class ElementRepository : IBaseRepository<Element>
    {
        private readonly AppDbContext _appDbContext;

        public ElementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Create(Element entity)
        {
            throw new NotImplementedException();
        }
       
        public Task Delete(Element entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Element> GetAll()
        {
            return _appDbContext.Elements;
        }

        public Task Update(Element entity)
        {
            throw new NotImplementedException();
        }
    }
}
