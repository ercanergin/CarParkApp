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
    /// Hangi günlerde ne iş yapacaksam bunun id sini tutmam lazım. (BaseModel)
    /// </summary>
    public class WorkingDay : BaseModel
    {
        /// <summary>
        /// Birden fazla dilde kullanılabilir. Çalışma günleri pazartesi, salı olabilir. Birden fazla günde çalışıyor olabilir.
        /// </summary>
        public ICollection<Translation> Translations { get; set; }
        /// <summary>
        /// Pazartesi birden fazla çalışma saatleri olabilir. Hangi saatlerde çalışıyor gibi.
        /// </summary>
        public ICollection<WorkingHour> WorkingHours { get; set; }
    }
}
