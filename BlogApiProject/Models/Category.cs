using System.ComponentModel.DataAnnotations;
namespace BlogApiProject.Models;
public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is Required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}