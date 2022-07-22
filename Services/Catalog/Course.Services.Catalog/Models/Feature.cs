using MongoDB.Bson.Serialization.Attributes;

namespace Course.Services.Catalog.Models
{
    public class Feature
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Duration { get; set; }
    }
}
