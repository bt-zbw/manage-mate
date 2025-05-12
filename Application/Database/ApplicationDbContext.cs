using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Contact> Contact { get; set; } = default!;
        public DbSet<Application.Models.Address> Address { get; set; } = default!;
    }
}
