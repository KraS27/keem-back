using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.DTO
{
    public class CreatingEmissionDTO
    {
        public int Id { get; set; }

        public int? Day { get; set; }

        public double ValueAvg { get; set; }

        public double ValueMax { get; set; }

        public int Year { get; set; }

        public int? Month { get; set; }

        public string Measure { get; set; }

        public int? IdPoi { get; set; }

        public int IdEnvironment { get; set; }

        public string ElementName { get; set; }
    }
}
