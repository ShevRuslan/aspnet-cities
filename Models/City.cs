namespace CitiesAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string District { get; set; }
        public string Subject { get; set; }
        public Coords Coords { get; set; }
    }
}
