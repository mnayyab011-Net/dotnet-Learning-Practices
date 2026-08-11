interface ICalculateSalary
{
    decimal CalculateSalary();
}
class Employee
{
public string Name;
    public int Id;
public Employee(string name, int id)
    {
        Name = name;
        Id = id;
    }
public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ID: {Id}");
    }
}
class Manager : Employee, ICalculateSalary
{
    public Manager(string name, int id) : base(name, id)
    {
    }
public decimal CalculateSalary()
    {
  return 700000;
    }
}class Developer : Employee, ICalculateSalary
{
    public Developer(string name, int id) : base(name, id)
    {

    }

    public decimal CalculateSalary()
    {
        return 600000;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager("Ali", 101);

        Console.WriteLine("Manager Details");
        manager.DisplayInfo();
        Console.WriteLine($"Salary: {manager.CalculateSalary()}");

        Console.WriteLine();

        Developer developer = new Developer("Ahmed", 102);

        Console.WriteLine("Developer Details");
        developer.DisplayInfo();
        Console.WriteLine($"Salary: {developer.CalculateSalary()}");
    }
}