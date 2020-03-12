using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PAAS.Entities.Base;

namespace PAAS.Entities
{
    public class Pun : BaseEntity
    {
        [BsonElement("n")] public string Name { get; set; }
        [BsonElement("c")] public string Content { get; set; }

        public Pun()
        {

        }
    }
}
