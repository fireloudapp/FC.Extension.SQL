using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FC.Extension.SQL.xTest.HelperModel
{

    public class PersonMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}