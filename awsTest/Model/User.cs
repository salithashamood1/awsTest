using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testApi.model
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty ;
        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty ;
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("mobilnumber")]
        public string MobileNumber { get; set; } = string.Empty;
    }
}
