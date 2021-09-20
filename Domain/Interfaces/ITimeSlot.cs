using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface ITimeSlot //: IDataEntitybase
    {
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public Guid? BookerId { get; set; }
        //public Guid RoomId { get; set; }

        //static readonly ITimeSlot Create;
    }
}
