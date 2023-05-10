using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int IdOfExpert { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
