namespace DatabaseLibrary.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public double Price { get; set; }
    }
}
