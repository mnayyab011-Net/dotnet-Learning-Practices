class InvalidStudentException : Exception
{
    public InvalidStudentException(string message) : base(message)
    {
    }
}
class Students
{
    public string Name;
    public int Id;
    public int Age;
    public int Number;
}
class Program
{
    static void Main(string[] args)
    {
        List<Students> students = new List<Students>();
        while (true)
        {
            try
            {
                Console.WriteLine("Students Management System");
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
                        if (s.Id <= 0)
                        {
                            throw new InvalidStudentException("Invalid ID");
                        }
                        Console.Write("Enter Name: ");
                        s.Name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        s.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Number: ");
                        s.Number = Convert.ToInt32(Console.ReadLine());
                        students.Add(s);
                        Console.WriteLine("Student Added Successfully.");
                        break;
                    case 2:
                        if (students.Count == 0)
                        {
                            throw new InvalidStudentException("No Students Found");
                        }
                        foreach (Students student in students)
                        {
                            Console.WriteLine("ID: " + student.Id);
                            Console.WriteLine("Name: " + student.Name);
                            Console.WriteLine("Age: " + student.Age);
                            Console.WriteLine("Number: " + student.Number);
                        }
                        break;
                    case 3:
                        Console.Write("Enter Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Students studentUpdate = students.Find(s => s.Id == id);
                        if (studentUpdate == null)
                        {
                            throw new InvalidStudentException("Student Not Found");
                        }

                        Console.Write("Enter New Name: ");
                        studentUpdate.Name = Console.ReadLine();
                        Console.Write("Enter New Age: ");
                        studentUpdate.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Number: ");
                        studentUpdate.Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Student Updated Successfully.");
                        break;
                    case 4:
                        Console.Write("Enter Student ID: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        Students studentDelete = students.Find(s => s.Id == deleteId);
                        if (studentDelete == null)
                        {
                            throw new InvalidStudentException("Student Not Found");
                        }
                        students.Remove(studentDelete);
                        Console.WriteLine("Student Deleted Successfully.");
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (InvalidStudentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Number Only");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation Completed Successfully");
            }
        }
    }
}
