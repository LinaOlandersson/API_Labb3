using API_Labb3.Data;
using API_Labb3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public InterestController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet("{personId}", Name = "GetPersonsInterests")]
        public async Task<ActionResult<List<string>>> GetInterestsByPersonId(int personId)
        {
            var person = await _context.Persons.FindAsync(personId);
            if (person == null)
            {
                return NotFound(new { errorMessage = "Det finns ingen person med detta id" });
            }

            var interests = await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Select(pi => pi.Interest.Title)
                .ToListAsync();

            if (interests.Count == 0)
            {
                return Ok(new List<string>());
            }

            return Ok(interests);
        }

       
    }
}
