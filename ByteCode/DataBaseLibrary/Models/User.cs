namespace DataBaseLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int TuristTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
