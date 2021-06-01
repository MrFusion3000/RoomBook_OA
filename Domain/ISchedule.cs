using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBook.Domain
{
    public interface ISchedule : IDataEntitybase
    {
        public List<TimeSlot> TimeSlots { get; set; }

        //static readonly ISchedule Create;
    }
}
