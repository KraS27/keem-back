using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.DB
{
    public class Poi
    {
        public int Id { get; set; }

        public int IdOfUser { get; set; }

        public int Type { get; set; }

        public int OwnerType { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }

        public string NameObject { get; set; }
    }
}
