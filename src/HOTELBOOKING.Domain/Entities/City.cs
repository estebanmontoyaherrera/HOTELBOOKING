namespace HOTELBOOKING.Domain.Entities
{
    public class City
    {
        public int? CityId { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; } = null!;
    }

}
