using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class PersonDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<InterestsAndLinksDto> Interests { get; set; } = new List<InterestsAndLinksDto>();
    }
}
