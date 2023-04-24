using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Models
{
    public class Element
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public string Cas { get; set; }

        public string Measure { get; set; }

        public string Formula { get; set; }

        public bool isHydrocarbon { get; set; }
    
        public bool isRigid { get; set; }

        public bool isVoc { get; set; }       
    }
}
