using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Interest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        //Navigation
        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
