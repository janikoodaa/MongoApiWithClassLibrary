using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataLibrary.Models
{
    // [BsonIgnoreExtraElements] Tällä saisi rajattua MongoDB:ssä mahdollisesti olevat muut propertyt pois ja otettu avastaan vain luokassa määritellyt propertyt
    public class Planet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("hasRings")]
        public bool HasRings { get; set; }

        [BsonElement("orderFromSun")]
        public int OrderFromSun { get; set; }

        [BsonElement("mainAtmosphere")]
        public string[] MainAtmosphere { get; set; } = Array.Empty<string>();

        [BsonElement("surfaceTemperatureC")]
        public PlanetSurfaceTemp SurfaceTemperature { get; set; } = new PlanetSurfaceTemp();
    }
}

