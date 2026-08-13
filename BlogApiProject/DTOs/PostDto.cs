namespace BlogApiProject.DTOs;
public class PostDto
{
    public string Title {get;set;}=string.Empty;
    public string Content {get;set;}=string.Empty;
    public int CategoryId {get;set;}
    public string? ImageUrl { get; set; }

}