using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models.DTOs
{
    public class LinkDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PersonInterestId { get; set; }
    }
}
