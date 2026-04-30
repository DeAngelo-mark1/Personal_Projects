using System;

namespace FancyFinances_Form.Models
{
    // Matches the existing database Users table columns
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Surname { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }          
        public string FavouriteAnimal { get; set; } = string.Empty;

        // Navigation property for the one-to-one relationship
        public Budget? Budget { get; set; }
    }
}
