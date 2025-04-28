using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Url]
        [Required]
        public string Url { get; set; } = string.Empty;
        public int PersonInterestId { get; set; }
        public PersonInterest? PersonInterest { get; set; }
    }
}
