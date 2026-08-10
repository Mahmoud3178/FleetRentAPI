using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class CarCategory : BaseEntity
    {
        public string Name { get; set; }
        public decimal DailyRate { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
