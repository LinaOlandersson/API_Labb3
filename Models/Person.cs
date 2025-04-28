using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        // Navigation
        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
