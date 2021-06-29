using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<TimeSlot> TimeSlots { get; set; }
        DbSet<User> ApplicationUsers { get; set; }

        Task<int> SaveChangesAsync();
    }
}