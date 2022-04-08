using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiesAPI.Models
{
    public class Coords
    {
        public int Id { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }

        public int CityKey { get; set; }
        public City City { get; set; }
    }
}
