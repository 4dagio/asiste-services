using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.API.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("Expedient")]
        public string Expedient { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserMobile { get; set; }
        public string ServicePlate { get; set; }
        public decimal ServicePrice { get; set; }
        public string StatusService { get; set; }


    }
}
