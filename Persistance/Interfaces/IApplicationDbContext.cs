using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        //DbSet<Product> Products { get; set; }
        DbSet<TimeSlot> TimeSlots { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Booker> Bookers { get; set; }
        DbSet<User> ApplicationUsers { get; set; }

        Task<int> SaveChangesAsync();
    }
}