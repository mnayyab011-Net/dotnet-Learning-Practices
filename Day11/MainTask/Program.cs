using System;
using System.Linq;
using System.Collections.Generic;
class product
{
    public int Id {get; set;}
    public String Name {get; set;} ="";
    public double Price {get; set;}
    public string Category {get; set;}="";
}
class Program
{
    static void Main()
    {
        List<product> products = new List<product>()
        {
            new product {Id =1 , Name = "Laptop" , Price = 80000 , Category = "Electronic"},
            new product {Id =2 , Name = "mobile" , Price = 500000 , Category = "Electronic"},
            new product {Id =3 , Name = "Computer" , Price = 100000 , Category = "Electronic"},
            new product {Id =4 , Name = "charger" , Price = 1500 , Category = "Electronic"},
            new product {Id =5 , Name = "headphones",Price = 500 , Category = "Electronic"},
            new product {Id =6 , Name = "Shirt" , Price = 4000 , Category = "Clothing"},
            new product {Id =7 , Name = "Jeans" , Price = 3000 , Category = "Clothing"},
            new product {Id =8 , Name = "Cap" ,   Price = 500 , Category = "Clothing"},
            new product {Id =9 , Name = "Shoes" , Price = 2000 , Category = "Clothing"},
            new product {Id =10 ,Name = "jacket" , Price = 3000 , Category = "Clothing"},
            new product {Id =11, Name = "book" , Price = 500 , Category = "Book"},
            new product {Id =12, Name = "notebook" , Price = 200 , Category = "Book"},
            new product {Id =13, Name = "pen" , Price = 100 , Category = "Book"},
            new product {Id =14, Name = "bag" , Price = 500 , Category = "Book"},
            new product {Id =15, Name = "calculator" , Price = 550 , Category = "Book"},
            new product {Id =16, Name = "chair" , Price = 1500 , Category = "Furniture"},
            new product {Id =17, Name = "Table" , Price = 1000 , Category = "Furniture"},
            new product {Id =18, Name = "sofa" , Price = 60000 , Category = "Furniture"},
            new product {Id =19, Name = "bed" , Price = 40000 , Category = "Furniture"},
            new product {Id =20, Name = "lamp" , Price = 2000 , Category = "Furniture"},

        };
        Console.WriteLine("Sort Product");
        var Sortproduct = products.OrderBy(p=> p.Id);
       foreach (var product in Sortproduct)
        {
             Console.WriteLine($"{product.Name} - {product.Id}");
        }
        Console.WriteLine("Group product");
        var groupproduct = products.GroupBy(p=> p.Category);
          foreach (var Category in groupproduct)
           {
           Console.WriteLine(Category.Key);
            foreach (var product in Category)
            {
          Console.WriteLine($"{product.Name} - {product.Category}");
         }
         }
         Console.WriteLine("Tope Five Expensive Product");
        var expensive = products.OrderByDescending(p =>p.Price)
        .Take(5);
        foreach (var product in expensive)
        {
             Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }
}
