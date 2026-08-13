using System.ComponentModel.DataAnnotations;
namespace BlogApiProject.Models;
public class User
{
    public int Id {get;set;}
    [Required(ErrorMessage ="Nameis Required")]
    [StringLength(50)]
    public string Name {get;set;}=string.Empty;
    [Required(ErrorMessage ="Email is Required")]
    [EmailAddress(ErrorMessage ="Invalid Email Format")]
    public string Email {get;set;} =string.Empty;
    [Required(ErrorMessage ="Password iS Required")]
    [StringLength (60,MinimumLength =6,ErrorMessage ="Password is AtLeast 6 Character")]
    public string PasswordHash {get;set;} =string.Empty;
}