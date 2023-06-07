using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_DAL.Implementation
{
    public class GdkRepository : IBaseRepository<Gdk>
    {
        private readonly AppDbContext _appDbContext;

        public GdkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Create(Gdk entity)
        {
            throw new NotImplementedException();
        }
    
        public Task Delete(Gdk entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Gdk> GetAll()
        {
            return _appDbContext.Gdks;
        }

        public Task Update(Gdk entity)
        {
            throw new NotImplementedException();
        }
    }
}
