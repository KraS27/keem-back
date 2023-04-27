using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Models
{
    public class Gdk
    {
        public int Id { get; set; }

        public string DangerCLass { get; set; }

        public int Environment { get; set; }

        public double MpcAverage_D { get; set; }

        public double MpcM_Ot { get; set; }

        public double Tsel { get; set; }
    }
}
