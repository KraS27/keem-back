using KEEM_Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Models
{
    public class Emission
    {
        public int Id { get; set; }

        public int? Day { get; set; }

        public int IdElement { get; set; }

        public int IdEnviroment { get; set; }

        public int? IdPoi { get; set; }
        public Poi? Poi { get; set; }

        public int IdPoligon { get; set; }

        public string Measure { get; set; }

        public int? Month { get; set; }

        public double? ValueAvg { get; set; }

        public double? ValueMax { get; set; }

        public int Year { get; set; }
    }
}
