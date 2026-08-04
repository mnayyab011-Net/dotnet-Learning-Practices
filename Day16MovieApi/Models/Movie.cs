using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MovieApi.Models;
public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;
    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;
    [BsonElement("director")]
    public string Director { get; set; } = string.Empty;
    [BsonElement("genre")]
    public string Genre { get; set; } = string.Empty;
    [BsonElement("releaseYear")]
    public int ReleaseYear { get; set; }
    [BsonElement("durationMinutes")]
    public int DurationMinutes { get; set; }
    [BsonElement("language")]
    public string Language { get; set; } = string.Empty;
    [BsonElement("rating")]
    public double Rating { get; set; }
    [BsonElement("posterUrl")]
    public string PosterUrl { get; set; } = string.Empty;
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}