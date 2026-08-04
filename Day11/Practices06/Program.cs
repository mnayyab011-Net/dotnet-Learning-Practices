using System;
using System.Linq;
using System.Collections.Generic;
class Movie
{
    public int Id {get; set;}
    public string Name {get; set;}
    public String Category {get; set;}
    public double Rating {get;set;}
    public int Year {get;set;}
}
class Program
{
    static void Main()
    {
        List <Movie> movies = new List<Movie>()
        {
            new Movie {Id =1 , Name = "Pk" , Category = "Comedy" , Rating = 5.0 , Year = 2019},
             new Movie {Id =2 , Name = "3 Idiots" , Category = "Comedy" , Rating = 4.5 , Year = 2019},
              new Movie {Id =3 , Name = "Nagin" , Category = "Drama" , Rating = 4.9 , Year = 2019},
        };
        var highRating = movies.Where(m => m.Rating > 4.8);
        foreach (var movie in highRating)
        {
            Console.WriteLine($"{movie.Name} - {movie.Rating}");
        }
        var names = movies.Select (m=>m.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            var sort = movies.OrderByDescending (m=> m.Rating);
            {
                foreach (var movie in sort)
                {
                   Console.WriteLine($"{movie.Name} - {movie.Rating}");
                }
                  var toprating = movies
                  .OrderByDescending(m => m.Rating)
                   .Take(2);
                 {
                foreach (var movie in toprating)
                {
                    Console.WriteLine($"{movie.Name} - {movie.Rating}");}
            }
        }
    }
}