using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
