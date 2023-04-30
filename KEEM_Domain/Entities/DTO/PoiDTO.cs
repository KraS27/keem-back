using KEEM_Domain.Entities.Models;

namespace KEEM_Domain.Entities.DTO
{
    public class PoiDTO
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }

        public string NameObject { get; set; }

        public string TypeName { get; set; }

        public bool isPolluted { get; set; }
    }
}
