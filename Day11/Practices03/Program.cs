using System;
using System.Linq;
using System.Collections.Generic;
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
    public string Department { get; set; }
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ali", Department = "CS", Age = 23, Marks = 80 },
            new Student { Id = 2, Name = "Nayyab", Department = "IT", Age = 28, Marks = 71 },
            new Student { Id = 3, Name = "Muqadas", Department = "Math", Age = 22, Marks = 90 },
            new Student { Id = 4, Name = "Aqsa", Department = "Urdu", Age = 26, Marks = 65 },
            new Student { Id = 5, Name = "Zain", Department = "IT", Age = 29, Marks = 97 }
        };
        Console.WriteLine("Students with Marks > 80");
        var result = students.Where(s => s.Marks > 80);
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        Console.WriteLine("Students Age > 20");
        var ageResult = students.Where(s => s.Age > 20);
        foreach (var student in ageResult)
        {
            Console.WriteLine($"{student.Name} - {student.Age}");
        }
        Console.WriteLine("Student Names");
        var names = students.Select(s => s.Name);
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("Department Wise Students");
        var groups = students.GroupBy(s => s.Department);
        foreach (var group in groups)
        {
            Console.WriteLine($"Department: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"{student.Name} - {student.Marks}");
            }
        }
    }
}