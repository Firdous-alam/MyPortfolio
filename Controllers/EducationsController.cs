using Firdous_Portfolio.Data;
using Firdous_Portfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firdous_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public EducationsController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
            var education = await _context.Educations.ToListAsync();
            if (education == null)
                return NotFound();

            return education;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
                return NotFound();

            return education;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducation(int id, Education education)
        {
            if (id != education.Id)
                return BadRequest();

            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Education>> AddEducation(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEducations), new { id = education.Id }, education);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
                return NotFound();

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
