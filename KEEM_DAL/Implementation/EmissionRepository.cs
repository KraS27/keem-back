using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;

namespace KEEM_DAL.Implementation
{
    public class EmissionRepository : IBaseRepository<Emission>
    {
        private readonly AppDbContext _dbContext;

        public EmissionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Emission entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Emission entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Emission> GetAll()
        {
            return _dbContext.Emissions;
        }

        public Task Update(Emission entity)
        {
            throw new NotImplementedException();
        }
    }
}
