using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    public class Address
    {
        /// <summary>
        /// Adres hangi ile bağlı
        /// </summary>
        public string CountyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
