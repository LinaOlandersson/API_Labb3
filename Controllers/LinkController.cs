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
    public class LinkController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public LinkController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet("person/{personId}", Name = "GetPersonsLinks")]
        public async Task<ActionResult<List<string>>> GetLinksByPersonId(int personId)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return NotFound(new { errorMessage = "Det finns ingen person med detta id" });
            }

            var links = await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .SelectMany(pi => pi.Links)
                .Select(l => l.Url)
                .ToListAsync();

            if (links.Count == 0)
            {
                return Ok(new List<string>());
            }

            return Ok(links);
        }

        [HttpGet("link/{linkId}", Name = "GetLinkById")]
        public async Task<ActionResult<Link>> GetLinkById(int linkId)
        {
            var link = await _context.Links.FindAsync(linkId);
            if (link == null)
            {
                return NotFound(new { errorMessage = "Ogiltigt id" });
            }
            return Ok(link);
        }

        [HttpPost("{personInterestId}/{url}", Name = "AddLink")]
        public async Task<ActionResult<LinkDto>> AddLink(int personInterestId, string url)
        {
            var personInterest = await _context.PersonInterests.FindAsync(personInterestId);

            if (personInterest == null)
            {
                return NotFound(new { errorMessage = "Ogiltigt id" });
            }
            
            var newLink = new Link
            {
                Url = url,
                PersonInterestId = personInterestId
            };
            _context.Links.Add(newLink);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLinkById), new { linkId = newLink.Id }, new LinkDto
            {
                Id = newLink.Id,
                Url = newLink.Url,
                PersonInterestId = newLink.PersonInterestId
            });
        }
    }
}
