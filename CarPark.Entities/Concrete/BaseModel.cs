using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    /// <summary>
    /// Birincil anahtar, primary key gibi
    /// </summary>
    public class BaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
