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
    /// (Şehir) Hepsini tek tek elle girmeyeceğiz, github da json dosyaları bulunmaktadır.
    /// </summary>
    public class City : BaseModel
    {
        public string Name { get; set; }
        /// <summary>
        /// Plaka
        /// </summary>
        public string Plate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        /// <summary>
        /// Tekirdağ ilinin içerisinde bulunan ilçeler
        /// </summary>
        public ICollection<County> Counties { get; set; }
    }
}
