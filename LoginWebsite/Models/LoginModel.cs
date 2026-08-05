using System.ComponentModel.DataAnnotations;
namespace LoginWebsite.Models;
public class LoginModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50)]
    public string Name {get;set;} =string.Empty;
    [Required(ErrorMessage ="Password must be At leaset 8 character and its must be Unique")]
    [StringLength (20)]
    public string Password {get;set;} = string.Empty;
}