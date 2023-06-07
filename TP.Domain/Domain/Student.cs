using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Domain.Domain
{
    public class Student
    {
        public Student()
        {
            CreationDate = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
