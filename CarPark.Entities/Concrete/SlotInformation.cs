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
    /// Hangi alanda olduğunu bilmem lazım. O yüzden uniqe id si olması lazım. (BaseModel)
    /// </summary>
    public class SlotInformation : BaseModel
    {
        /// <summary>
        /// Mavi 1, A,B,C vb. olduğu için birden fazla isimlendirme olabilir.
        /// </summary>
        public ICollection<Translation> Translations { get; set; }
    }
}
