using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBook.Domain
{
    public interface IDataEntitybase
    {
        Guid ID { get; set; }
        DateTime CreatedUTC { get; set; }
    }
}
