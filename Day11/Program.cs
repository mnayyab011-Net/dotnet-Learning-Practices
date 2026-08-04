using System;
using System.Linq;
using System.Collections.Generic;
class Product
{
    public int Id {get; set;}
    public string Name {get ; set;}
    public string Category {get; set;}
    public int Price {get; set;}
}
class Program
{
    static void Main ()
    {
        List<Product> products =new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 5000 },
        new Product { Id = 2, Name = "Mobile", Category = "Electronics", Price = 4000 },
        new Product { Id = 3, Name = "Tablet", Category = "Electronics", Price = 3000 },
        new Product { Id = 4, Name = "Chair", Category = "Furniture", Price = 1500 },
        new Product { Id = 5, Name = "Bag", Category = "Accessories", Price = 800 },
        new Product { Id = 6, Name = "Bottle", Category = "Accessories", Price = 500 }
    }
    var ProductCount = products.Count(p=>p.Id);
    Console.WriteLine("ProductCount");
    var Maxprice = products.Max(p=>p.Price);
    Console.WriteLine(Maxprice);
    var Minprice =products.Min (p=>p.Price)
    Console.WriteLine("Minprice");
}
}