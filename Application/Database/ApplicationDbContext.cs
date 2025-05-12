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
        public DbSet<Application.Models.Court> Court { get; set; } = default!;
        public DbSet<Application.Models.Hall> Hall { get; set; } = default!;
        public DbSet<Application.Models.User> User { get; set; } = default!;
        public DbSet<Application.Models.Reservation> Reservation { get; set; } = default!;
    }
}
