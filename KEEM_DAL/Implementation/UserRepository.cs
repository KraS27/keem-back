using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_DAL.Implementation
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
