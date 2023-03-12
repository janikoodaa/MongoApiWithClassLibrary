using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataLibrary.Models
{
    public class PlanetSurfaceTemp
    {
        [BsonElement("max")]
        public decimal? Max { get; set; }

        [BsonElement("min")]
        public decimal? Min { get; set; }

        [BsonElement("mean")]
        public decimal? Mean { get; set; }
    }
}

