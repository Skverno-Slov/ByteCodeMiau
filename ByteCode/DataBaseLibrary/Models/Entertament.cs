namespace DataBaseLibrary.Models
{
    public class Entertament
    {
        public int EntertamentId { get; set; }
        public int CityId { get; set; }
        public int EntertamentTypeId { get; set; }
        public int TuristTypeId { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public string EntertamentName { get; set; }
        public string? Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string SiteLink { get; set; }
        public decimal Price { get; set; }

    }
}
