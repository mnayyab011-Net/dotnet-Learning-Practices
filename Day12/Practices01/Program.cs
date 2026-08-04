using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("order Piza");
        Task PizaTask=MakePizaAsync();
        Console.WriteLine("start using Mobile Phone");
        await PizaTask;
        Console.WriteLine("order Arrived");
    }
    static async Task MakePizaAsync ()
    {
        Console.WriteLine("Chief Making Piza");
        await Task.Delay(3000);
        Console.WriteLine("Piza Ready");
    }
}