namespace DataBaseLibrary.Models
{
    public class Entertament
    {
        public int EntertamentId { get; set; }
        public int CityId { get; set; }
        public int EntertamentTypeId { get; set; }
        public int TuristTypeId { get; set; }
        public string Address { get; set; }
        public string EntertamentName { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SiteLink { get; set; }
        public double Price { get; set; }

    }
}
