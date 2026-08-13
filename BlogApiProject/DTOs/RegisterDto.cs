using System.ComponentModel.DataAnnotations;
namespace BlogApiProject.DTOs;
public class RegisterDto
{
    [Required(ErrorMessage = "Name is Required")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress(ErrorMessage = "Invalid Email Format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please Enter Your Password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password At Least 6 Character")]
    public string Password { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}