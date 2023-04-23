using KEEM_Domain.Entities.DB;

namespace KEEM_Domain.Entities.Models
{
    public class TypeOfObject
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public string Kved { get; set; }

        public string Name { get; set; }

        public List<Poi> Pois { get; set; }
    }
}
