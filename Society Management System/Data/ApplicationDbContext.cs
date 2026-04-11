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

        // ✅ Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<HallBooking> HallBookings { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Notice> Notices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// ---------------- VISITOR ----------------
            //modelBuilder.Entity<Visitor>()
            //    .HasOne(v => v.User)
            //    .WithMany(u => u.Visitors)   // 👈 Add List<Visitor> in User model
            //    .HasForeignKey(v => v.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// ---------------- HALL BOOKING ----------------
            //modelBuilder.Entity<HallBooking>()
            //    .HasOne(h => h.User)
            //    .WithMany(u => u.HallBookings) // 👈 Add List<HallBooking> in User
            //    .HasForeignKey(h => h.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// ---------------- COMPLAINT ----------------
            //modelBuilder.Entity<Complaint>()
            //    .HasOne(c => c.User)
            //    .WithMany(u => u.Complaints) // 👈 Add List<Complaint> in User
            //    .HasForeignKey(c => c.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// ---------------- NOTICE ----------------
            //modelBuilder.Entity<Notice>()
            //    .HasOne(n => n.Creator)
            //    .WithMany(u => u.Notices) // 👈 Add List<Notice> in User
            //    .HasForeignKey(n => n.CreatedBy)
            //    .OnDelete(DeleteBehavior.SetNull);

            //// ---------------- DEFAULT VALUES ----------------
            //modelBuilder.Entity<Complaint>()
            //    .Property(c => c.Status)
            //    .HasDefaultValue("Pending");

            modelBuilder.Entity<Complaint>()
                .Property(c => c.ComplaintDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}