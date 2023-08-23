using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;

namespace SchoolApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {     
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Price)
                .HasPrecision(18, 2); // Adjust the precision and scale as needed
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Registerer> Registerers { get; set; }
    }
}
