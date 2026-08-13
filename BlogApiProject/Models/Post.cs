using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BlogApiProject.Models;
public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Title is Required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Title AtLeast 10 Charcater")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Enter your Content")]
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public User? User { get; set; }
    public Category? Category { get; set; }
}