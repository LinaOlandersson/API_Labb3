using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class InterestsAndLinksDto
    {
        public string Title { get; set; } = string.Empty;
        public List<string> Links { get; set; } = new List<string>();
    }
}
