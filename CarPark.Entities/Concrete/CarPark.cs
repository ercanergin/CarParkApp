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
    /// Otopark Şubeler
    /// </summary>
    public class CarPark : BaseModel
    {
        /// <summary>
        /// Otopark ismi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Otoparkın birden fazla numaraları olabilir.
        /// </summary>
        public string[] PhoneNumbers { get; set; }
        public Address Address { get; set; }
        /// <summary>
        /// otoparkta çalışan personeller
        /// </summary>
        public string[] Personels { get; set; }
        public string WebSite { get; set; }
        public string[] EmailAddresses { get; set; }
        /// <summary>
        /// Oroparkın çalışma günleri
        /// </summary>
        public ICollection<WorkingDay> WorkingDays { get; set; }
        /// <summary>
        /// Kat bilgileri
        /// </summary>
        public ICollection<FloorInformation> Floors { get; set; }
    }
}
