using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetAllPersons")]
        public async Task<ActionResult<ICollection<PersonDto>>> GetAllPersons()
        {
            return Ok(await _context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Interest)
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Links)
                .Select(p => new PersonDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Interests = p.PersonInterests
                    .Select(pi => new InterestsAndLinksDto
                    {
                        Title = pi.Interest.Title,
                        Links = pi.Links
                        .Select(l => l.Url)
                        .ToList()
                    }).ToList()
                }).ToListAsync());
        }

        [HttpPut("{personId}/{interestIdToAdd}", Name = "AddInterestToPersonById")]
        public async Task<IActionResult> AddInterestToPerson(int personId, int interestIdToAdd)
        {
            var personToUpdate = await _context.Persons.FindAsync(personId);
            var interestToAdd = await _context.Interests.FindAsync(interestIdToAdd);

            if (personToUpdate == null || interestToAdd == null)
            {
                return NotFound(new { errorMessage = "Ogiltigt id" });
            }

            var alreadyExists = await _context.PersonInterests
                .AnyAsync(pi => pi.PersonId == personId && pi.InterestId == interestIdToAdd);

            if (alreadyExists)
            {
                return Conflict(new { errorMessage = "Personen har redan detta intresse" });
            }

            _context.PersonInterests.Add(new PersonInterest
            {
                PersonId = personId,
                InterestId = interestIdToAdd
            });

            await _context.SaveChangesAsync();

            return Ok(new {message = $"IntresseId {interestIdToAdd} har adderats till personId {personId}"});
        }
    }
}
