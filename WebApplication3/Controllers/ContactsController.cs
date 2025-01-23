using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
        {
            _context = context;
        }

        // Get all contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        // Get contact by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // Search contact by name
        [HttpGet("search")]
        public async Task<IActionResult> SearchContact([FromQuery] string name)
        {
            var contacts = await _context.Contacts
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%"))
                .ToListAsync();

            return Ok(contacts);
        }

        // Create a new contact
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // Update a contact
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingContact = await _context.Contacts.FindAsync(id);

            if (existingContact == null)
                return NotFound();

            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete a contact
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
