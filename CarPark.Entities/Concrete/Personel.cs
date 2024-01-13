using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    //Concrete: Somut nesneleri ifade eder.
    public class Personel : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// personel role yetkileri, admin, süper admin vb.
        /// </summary>
        public string[] Roles { get; set; }
        public PersonelContact PersonelContact { get; set; }
        public ICollection<Address> Addresses { get; set; }
        /// <summary>
        /// Personel aktif mi değil mi?
        /// </summary>
        public short Status { get; set; }
        /// <summary>
        /// Personel ne zaman oluşturuldu?
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Personel ne zaman güncellendi?
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
