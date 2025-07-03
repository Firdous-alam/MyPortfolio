using Firdous_Portfolio.Data;
using Firdous_Portfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firdous_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public ContactMessagesController(PortfolioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetContactMessages()
        {
            var contacts = await _context.ContactMessages.ToListAsync();
            if (contacts == null)
                return NotFound();

            return contacts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMessage>> GetContactMessage(int id)
        {
            var contacts = await _context.ContactMessages.FindAsync(id);
            if (contacts == null)
                return NotFound();

            return contacts;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactMessage(int id, ContactMessage contacts)
        {
            if (id != contacts.Id)
                return BadRequest();

            _context.Entry(contacts).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ContactMessage>> AddContactMessage(ContactMessage contacts)
        {
            _context.ContactMessages.Add(contacts);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContactMessages), new { id = contacts.Id }, contacts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            var contacts = await _context.ContactMessages.FindAsync(id);
            if (contacts == null)
                return NotFound();

            _context.ContactMessages.Remove(contacts);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
