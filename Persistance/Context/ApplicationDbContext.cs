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

        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Domain.Entities.Booker> Bookers { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");
            //modelBuilder.Entity<Room>()
            //    .Property(r => r.ID)
            //    .IsRequired();

            modelBuilder.Entity<Room>()
                .HasMany(r => r.TimeSlots)
                .WithOne();
            modelBuilder.Entity<Room>()
                .Navigation(r => r.TimeSlots);
                    //.UsePropertyAccessMode(PropertyAccessMode.Property);

            //modelBuilder.Entity<Booker>()
                //.HasMany(b => b.TimeSlots)
                //.WithOne();
            //modelBuilder.Entity<Booker>()
            //    .Navigation(b => b.TimeSlots)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);

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
