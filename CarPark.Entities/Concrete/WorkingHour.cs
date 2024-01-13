using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    public class WorkingHour
    {
        /// <summary>
        /// Çalışma saatleri farklı dillerde pm ,am olarak değiştiği için
        /// </summary>
        public ICollection<Translation> Translations { get; set; }
    }
}
