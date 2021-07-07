using Persistance.Interfaces;
using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Persistance.Models;

namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<TimeSlot>().ToTable("TimeSlots");
            modelBuilder.Entity<Room>().ToTable("Rooms");

            base.OnModelCreating(modelBuilder);
        }

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
