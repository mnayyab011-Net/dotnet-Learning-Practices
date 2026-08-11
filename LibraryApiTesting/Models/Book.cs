namespace LibraryApiTesting.Models;
public class Book
{ 
   public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public String Category { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } 
    public decimal Price { get; set; }

}
