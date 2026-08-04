using System;
using System.Linq;
class Student
{
     public int Id {get; set;}
    public string Name {get; set;}
     public int Age {get; set;}
    public int Marks {get;set;}
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ali", Age = 27, Marks = 80 },
            new Student { Id = 2, Name = "Nayyab", Age = 23, Marks = 89 },
            new Student { Id = 3, Name = "Aleena", Age = 20, Marks = 90 },
            new Student { Id = 4, Name = "Muqadas", Age = 23, Marks = 95 },
            new Student { Id = 5, Name = "Aqsa", Age = 23, Marks = 75 },
        };
        var names= students.Select(s=>s.Name);
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
      var result = students.Where(s=> s.Marks>80);
      foreach (var Student in result)
      {
        Console.WriteLine($"{Student.Name} , {Student.Marks}");
      }
    }
    }
