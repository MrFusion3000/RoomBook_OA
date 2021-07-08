using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Persistance.Models;
using Persistance.Interfaces;

namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<TimeSlot>().ToTable("TimeSlots");
            modelBuilder.Entity<Room>().ToTable("Rooms");
            //modelBuilder.Entity<User>().ToTable("ApplicationUsers");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

        //public DbSet<Product> Products { get; set; }

        //public DbSet<Role> Roles { get; set; }
        //public DbSet<APIUser> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
