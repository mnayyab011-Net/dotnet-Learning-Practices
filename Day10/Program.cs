class Students
{
    public int Id;
    public int Number;
    public string? Name;
    public int Age;

}
class Program
{
    static void Main (string [] args)
    {
        Dictionary <int , Students> students = new Dictionary<int, Students>();
       while (true)
       {
        Console.WriteLine("Students Management System");
        Console.WriteLine("1. Add students");
        Console.WriteLine("2. View students");
        Console.WriteLine ("3. Update students");
        Console.WriteLine("4. Delete Students");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your Choices");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
            {
                case 1:
                    Students s = new Students();
                    Console.WriteLine("Enter student id");
                    s.Id = Convert.ToInt32(Console.ReadLine());
                    if (students.ContainsKey(s.Id))
                    {
                        Console.WriteLine("studnts already exit");
                    }
                    else
                    {
                        Console.WriteLine("Enter Students Nmae");
                        s.Name= Console.ReadLine();
                        Console.WriteLine("Enter students Age");
                        s.Age=Convert.ToInt32(Console.ReadLine());
                       Console.WriteLine("Enter students Number");
                       s.Number=Convert.ToInt32(Console.ReadLine());
                       students.Add(s.Id,s);
                       Console.WriteLine("Student Add successfully");
                    }
                     break;
                       case 2:
                            {
                              if (students.Count == 0)
                        {
                            Console.WriteLine("No students found");
                        }
                        else
                        {
                            foreach (var item in students)
                            {
                                Console.WriteLine("ID" + item.Value.Id);
                                Console.WriteLine("Name" + item.Value.Name);
                                Console.WriteLine("Number" + item.Value.Number);
                                Console.WriteLine("Age" + item.Value.Age);
                            }
                        }
                        break;
                            }
                           case 3:
                            {
                                Console.WriteLine("Enter student update Id");
                                int updateId=Convert.ToInt32(Console.ReadLine());
                                if (students.ContainsKey(updateId))
                                {
                                Students updateStudent = students[updateId];
                                Console.WriteLine("Enter students Name");
                                updateStudent.Name = Console.ReadLine();
                                Console.WriteLine("Enter students Number");
                                updateStudent.Number=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter students Age");
                                updateStudent.Age=Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("students not Found");
                        }
                        break;
                            }   
                             case 4:
                                   {
                                      Console.Write("Enter Student ID to Delete: ");
                                    int deleteId = Convert.ToInt32(Console.ReadLine());
                                    if (students.ContainsKey(deleteId)) {
                                      students.Remove(deleteId);
                                     Console.WriteLine("Student Deleted Successfully.");
                                      }
                                     else
                                      {
                                       Console.WriteLine("Student Not Found.");
                                       }
                                          break;
                                        }
                                        case 5:
                                        {
                                        Console.WriteLine("Thanksyou");
                                        return;
                                        }
                                        default:
                                        {
                                        Console.WriteLine("invaild choices");
                                        break;
                                        }
            }
       }
    }
}