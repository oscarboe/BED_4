using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Heathstone.Models
{
    public class Set
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        [JsonPropertyName("collectibleCount")]
        public int collectibleCount { get; set; }
    }
}
