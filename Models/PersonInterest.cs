namespace API_Labb3.Models
{
    public class PersonInterest
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public int InterestId { get; set; }
        public Interest Interest { get; set; } = null!;

        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
