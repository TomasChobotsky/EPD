using Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class EpdContext : DbContext
    {
        public EpdContext(DbContextOptions<EpdContext> options)
            : base(options)
        {
        }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "123",
                    LastName = "123",
                    Username = "123",
                    Password = "123"
                });
        }
    }
}