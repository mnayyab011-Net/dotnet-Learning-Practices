using System.Linq;
class Program
{
static void Main(string[] args)
    {
        List<int> students = new List<int>
        {
            1,2,3,4,5
        };
        var result = students.Where(x => x > 2);
        foreach(var number in result)
        {
            Console.WriteLine(number);
        }
    }
}