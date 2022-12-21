using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Heathstone.Models
{
    public class CardType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
