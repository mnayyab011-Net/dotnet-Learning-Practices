using System.ComponentModel.DataAnnotations;
namespace BlogApiProject.DTOs;
public class LoginDto
{
    [Required(ErrorMessage ="Please Enter your Email")]
    [EmailAddress(ErrorMessage ="Invaild Email Format")]
    public string Email {get;set;} = string.Empty;
    [Required(ErrorMessage ="Password is required")]
    [StringLength(60,MinimumLength =6,ErrorMessage ="Password AtLeast 6 Character")]
    public string Password {get;set;} =string.Empty;
}