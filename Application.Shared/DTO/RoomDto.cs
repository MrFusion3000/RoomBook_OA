﻿using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Shared.DTO
{
    public class RoomDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        
        public int AnyVacantSlot { get; set; }
        public TimeSlot FirstVacantTimeSlot { get; set; }

        //Navigation properties
        public List<TimeSlotDto> TimeSlots { get; set; }
        //public List<BookerDto> Bookers { get; set; }
    }
}