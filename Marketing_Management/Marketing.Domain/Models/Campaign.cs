using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Marketing.Domain.Models;

public class Campaign
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}
