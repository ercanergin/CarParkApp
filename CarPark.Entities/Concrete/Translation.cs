using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    public class Translation
    {
        /// <summary>
        /// en-US,tr-TR
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Culture'yi karşılamak için key name belirtiyorum. Örnek; tr-TR de Pazartesi gibi. 
        /// </summary>
        public string Name { get; set; }
    }
}
