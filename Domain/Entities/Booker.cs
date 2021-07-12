using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booker : IBooker
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        public static Booker Create(string name)
        {
            return new Booker()
            {
                ID = Guid.NewGuid(),
                Name = name,
                CreatedUTC = DateTime.UtcNow
            };
        }
    }
}
