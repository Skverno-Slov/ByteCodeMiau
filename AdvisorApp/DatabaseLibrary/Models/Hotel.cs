namespace DatabaseLibrary.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public int CityId { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string SiteLink { get; set; }
    }
}
