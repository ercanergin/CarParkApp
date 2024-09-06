using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    //Concrete: Somut nesneleri ifade eder.
    [CollectionName("Personel")]
    public class Personel : MongoIdentityUser
    {
        public Personel()
        {
            CreatedDate = DateTime.Now;
            Status = 1;
        }
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
