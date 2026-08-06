using System.ComponentModel.DataAnnotations;
namespace LoginWebsite.Models;
public class RegisterModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [StringLength(20, MinimumLength = 6,
        ErrorMessage = "Password must be between 6 and 20 characters.")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}