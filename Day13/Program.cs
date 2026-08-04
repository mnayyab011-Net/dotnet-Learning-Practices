using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Students
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Age { get; set; }
    public int Number { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "students.json";
        List<Students> students = new List<Students>();

        // Load data from JSON file
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Students>>(json) ?? new List<Students>();
        }

        while (true)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Students s = new Students();

                    Console.Write("Enter ID: ");
                    s.Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    s.Age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Number: ");
                    s.Number = Convert.ToInt32(Console.ReadLine());

                    students.Add(s);

                    SaveToJson(filePath, students);

                    Console.WriteLine("Student Added Successfully.");
                    break;

                case 2:
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No Students Found.");
                    }
                    else
                    {
                        Console.WriteLine("\nStudents List");

                        foreach (Students student in students)
                        {
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("ID     : " + student.Id);
                            Console.WriteLine("Name   : " + student.Name);
                            Console.WriteLine("Age    : " + student.Age);
                            Console.WriteLine("Number : " + student.Number);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Students studentUpdate = students.Find(student => student.Id == id);

                    if (studentUpdate != null)
                    {
                        Console.Write("Enter New Name: ");
                        studentUpdate.Name = Console.ReadLine();

                        Console.Write("Enter New Age: ");
                        studentUpdate.Age = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Number: ");
                        studentUpdate.Number = Convert.ToInt32(Console.ReadLine());

                        SaveToJson(filePath, students);

                        Console.WriteLine("Student Updated Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Student ID: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());

                    Students studentDelete = students.Find(student => student.Id == deleteId);

                    if (studentDelete != null)
                    {
                        students.Remove(studentDelete);

                        SaveToJson(filePath, students);

                        Console.WriteLine("Student Deleted Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting Program...");
                    return;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }

    static void SaveToJson(string filePath, List<Students> students)
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }
}