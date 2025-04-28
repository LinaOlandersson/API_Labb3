using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace API_Labb3.Data
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 2, FirstName = "Marcus", LastName = "Lindberg", PhoneNumber = "070-1234567" },
                new Person { Id = 3, FirstName = "Sara", LastName = "Ekström", PhoneNumber = "073-9876543" },
                new Person { Id = 1, FirstName = "Jenny", LastName = "Olandersson", PhoneNumber = "076-8400716" },
                new Person { Id = 4, FirstName = "Erik", LastName = "Svensson", PhoneNumber = "072-5554321" },
                new Person { Id = 5, FirstName = "Elin", LastName = "Andersson", PhoneNumber = "076-1122334" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Fiska", Description = "Vara ute i naturen med spö i handen" },
                new Interest { Id = 2, Title = "Läsa böcker", Description = "Fördjupa sig i romaner och facklitteratur" },
                new Interest { Id = 3, Title = "Programmera", Description = "Skapa program och appar med kod" },
                new Interest { Id = 4, Title = "Träna på gym", Description = "Styrketräning och kondition" },
                new Interest { Id = 5, Title = "Resa", Description = "Utforska nya platser och kulturer" }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { Id = 2, PersonId = 2, InterestId = 3 },
                new PersonInterest { Id = 3, PersonId = 2, InterestId = 5 },
                new PersonInterest { Id = 4, PersonId = 3, InterestId = 1 },
                new PersonInterest { Id = 5, PersonId = 4, InterestId = 2 },
                new PersonInterest { Id = 6, PersonId = 4, InterestId = 3 },
                new PersonInterest { Id = 7, PersonId = 5, InterestId = 4 }
                );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, PersonInterestId = 1, Url = "www.fiske.nu"},
                new Link { Id = 2, PersonInterestId = 1, Url = "www.vattendjur.se"},
                new Link { Id = 3, PersonInterestId = 2, Url = "www.koda.nu"},
                new Link { Id = 4, PersonInterestId = 3, Url = "www.vagabond.se"},
                new Link { Id = 5, PersonInterestId = 4, Url = "www.gofish.org"},
                new Link { Id = 6, PersonInterestId = 5, Url = "www.bokladan.se"},
                new Link { Id = 7, PersonInterestId = 5, Url = "www.varbergsbibliotek.se"},
                new Link { Id = 8, PersonInterestId = 6, Url = "www.codecademy.com"},
                new Link { Id = 9, PersonInterestId = 7, Url = "www.gymma.nu"},
                new Link { Id = 10, PersonInterestId = 7, Url = "www.superstark.nu"}
                );
        }
    }
}
