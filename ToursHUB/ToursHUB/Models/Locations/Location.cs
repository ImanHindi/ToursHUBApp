using SQLite;

namespace ToursHUB.Models.Locations
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
