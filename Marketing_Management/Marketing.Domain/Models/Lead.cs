using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Marketing.Domain.Enums;

namespace Marketing.Domain.Models
{
    public class Lead
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Observation { get; set; }

        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
