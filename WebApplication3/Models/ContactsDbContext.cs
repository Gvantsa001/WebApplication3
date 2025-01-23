using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
