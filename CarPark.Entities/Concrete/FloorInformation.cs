using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    /// <summary>
    /// Hangi katta olduğumu bilmem lazım (BaseModel'i türettim)
    /// </summary>
    public class FloorInformation : BaseModel
    {
        /// <summary>
        /// Kat numarası
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Kattaki alanları belirtiyor. 1. katta 25 alan bulunduğundan 25 tane park edilebilir. 2. katta B1,B2,B3 alanları var gibi.
        /// </summary>
        public ICollection<SlotInformation> Slots { get; set; }
    }
}
