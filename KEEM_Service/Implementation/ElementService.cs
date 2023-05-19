using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.Models;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Service.Implementation
{
    public class ElementService : IElementService
    {
        private readonly IBaseRepository<Element> _elementRepository;

        public ElementService(IBaseRepository<Element> elementRepository)
        {
            _elementRepository = elementRepository;
        }

        public async Task<Element> GetElementByName(string name)
        {
            try
            {
                return await _elementRepository.GetAll().FirstOrDefaultAsync(e => e.Name == name);
            }
            catch(Exception ex)  
            {
                throw (ex);
            }
        }
    }
}
