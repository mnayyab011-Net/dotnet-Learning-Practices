using System;
using System.Linq;
using System.Collections.Generic;
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Marks { get; set; }
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ali", Department = "CS", Marks = 80 },
            new Student { Id = 2, Name = "Nayyab", Department = "IT", Marks = 70 },
            new Student { Id = 3, Name = "Muqadas", Department = "CS", Marks = 82 },
            new Student { Id = 4, Name = "Aqsa", Department = "Math", Marks = 90 },
        };
        var group = students.GroupBy(s => s.Department);

        foreach (var item in group)
        {
            Console.WriteLine($"Department: {item.Key}");
            foreach (var student in item)
            {
                Console.WriteLine($"{student.Name} - {student.Department}");
            }
        }
        var result = students.OrderBy(s => s.Marks);
        Console.WriteLine("Marks Low to High");
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        var descending = students.OrderByDescending(s => s.Marks);
        Console.WriteLine("Marks High to Low");
        foreach (var student in descending)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
    }
}