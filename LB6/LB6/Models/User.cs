namespace Lb6.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public string GetInfo()
        {
            return $"{FirstName} {LastName} ({Age} років) - {Email}";
        }
    }
}