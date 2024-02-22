using CarPark.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataAccess.Context
{
    /// <summary>
    /// Db bağlantı yeri
    /// </summary>
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }
        /// <summary>
        /// Collection döndüren metod(tabloları)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        /// <summary>
        /// Database döndüren metod
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase GetDatabase() { return _database; }
    }
}
