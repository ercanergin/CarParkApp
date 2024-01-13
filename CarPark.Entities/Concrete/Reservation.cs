using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    public class Reservation : BaseModel
    {
        /// <summary>
        /// Otoparka girdiğim anda resmin path ini tutuyoruz.
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Plaka bilgisi
        /// </summary>
        public string Plate { get; set; }
        /// <summary>
        /// Otopark giriş tarihi, fişteki başlangıç tarihi
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// Çıkış tarihi, boş geçilebilir.
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Ücret
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Araç çıkmış mı çıkmamış mı?
        /// </summary>
        public bool IsExit { get; set; }
        /// <summary>
        /// Ödeme alın dı mı alınmadı mı?
        /// </summary>
        public bool IsPayment { get; set; }
        /// <summary>
        /// Rezervasyon detayı
        /// </summary>
        public ReservationDetail ReservationDetail { get; set; }
    }
}
