using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Settings
{
    /// <summary>
    /// MongoDbContext için settings ayarları,appsettingsdeki değerleri burdaki isimlerle alıcam.
    /// </summary>
    public class MongoSettings
    {
        public string ConnectionString;
        public string Database;
    }
}
