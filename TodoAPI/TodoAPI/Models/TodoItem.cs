using MongoDB.Bson.Serialization.Attributes;

namespace TodoAPI.Models;

public class TodoItem
{
    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
}