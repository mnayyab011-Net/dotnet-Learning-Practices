class Employee
{
}
class Manager : Employee
{
    public void ManageTeam()
    {
        Console.WriteLine("Manager Manage Teams");
    }
}
class Developer : Employee
{
    public void WriteCode()
    {
        Console.WriteLine("Developer Write Code");
    }
}
class Team : Employee
{
}
class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Developer();
        Developer d = emp as Developer;
        if (d != null)
        {
            d.WriteCode();
        }
        else
        {
            Console.WriteLine("Employee is not Developer");
        }
    }
}