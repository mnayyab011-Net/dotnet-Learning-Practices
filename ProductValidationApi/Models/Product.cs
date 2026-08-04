using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ProductValidationApi.Models;
public class Product
{
    public int Id {get;set;}
    [Required(ErrorMessage ="Name is Required")]
    [StringLength(50,ErrorMessage ="Limition of 50 Character")]
    public string Name {get;set;} = String.Empty;
    [Required(ErrorMessage ="Quantity is Required")]
    [Range(1,1000,ErrorMessage ="Quantity must between 1 to 1000")]
    public int Quantity {get;set;}
    [Required(ErrorMessage = "Category is Required")]
    [StringLength(50,ErrorMessage ="can't Exceed 50 Character")]
    public string Category {get;set;} = String.Empty;
}