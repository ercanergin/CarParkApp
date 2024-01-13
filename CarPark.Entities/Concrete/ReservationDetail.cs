using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    /// <summary>
    /// Araç hangi otopark, hangi katta ve hangi alanda olduğunu bilmem lazım.
    /// </summary>
    public class ReservationDetail
    {
        public string SlotId { get; set; }
        public string FloorId { get; set; }
        public string CarParkId { get; set; }
    }
}
