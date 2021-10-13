using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.Common;

namespace Domain.Entities
{
    public class Room : BaseEntity, IRoom //IDataEntitybase,
    {
        //[Required]
        //public Guid ID { get; set; }
        public string Name { get; set; }
        //public DateTime CreatedUTC { get; set; }
        public int Placement { get; set; }

        //Navigation properties
        public List<TimeSlot> TimeSlots { get; set; }

        public static IRoom Create(Guid id, string name, DateTime createdUTC, int placement)
        {
            return new Room()
            {
                ID = id,
                Name = name,
                CreatedUTC = createdUTC,
                Placement = placement
            };
        }
    }
}
