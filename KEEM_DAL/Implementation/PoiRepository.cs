using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;

namespace KEEM_DAL.Implementation
{
    public class PoiRepository : IBaseRepository<Poi>
    {
        private readonly AppDbContext _appDbContext;

        public PoiRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Create(Poi entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Poi entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Poi> GetAll()
        {
            return _appDbContext.Pois;
        }

        public Task Update(Poi entity)
        {
            throw new NotImplementedException();
        }
    }
}
