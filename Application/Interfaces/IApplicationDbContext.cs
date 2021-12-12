using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TimeSlot> TimeSlots { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Booker> Bookers { get; set; }

        Task<int> SaveChangesAsync();
    }
}
