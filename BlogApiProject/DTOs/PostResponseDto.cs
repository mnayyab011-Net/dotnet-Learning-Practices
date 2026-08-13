namespace BlogApiProject.DTOs;
public class PostResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}