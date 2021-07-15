using System;
using Domain.Entities;

namespace Application.Shared.Rooms
{
    public class RoomDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        
        public int AnyVacantSlot { get; set; }
        public TimeSlot FirstVacantTimeSlot { get; set; }
    }
}