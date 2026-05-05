using Microsoft.EntityFrameworkCore;
using Society_Management_System.Models;

namespace Society_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<HallBooking> HallBookings { get; set; }
        public DbSet<Admin> Admins { get; set; }

        // Add other DbSets (User, Notice, Visitor, etc.) as needed
    }
}