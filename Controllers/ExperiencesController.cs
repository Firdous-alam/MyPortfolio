using Firdous_Portfolio.Data;
using Firdous_Portfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firdous_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public ExperiencesController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
        {
            var experience = await _context.Experiences.ToListAsync();
            if (experience == null)
                return NotFound();

            return experience;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
                return NotFound();

            return experience;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExperience(int id, Experience experience)
        {
            if (id != experience.Id)
                return BadRequest();

            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExperiences), new { id = experience.Id }, experience);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
                return NotFound();

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
