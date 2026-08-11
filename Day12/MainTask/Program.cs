using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("Start Fetching Data");
        Task fetchingTask = fetchingDataAsync();
        Console.WriteLine("Waiting...");
        await fetchingTask;
        Console.WriteLine("Data fetch Successfully");
    }
    static async Task fetchingDataAsync ()
    {
        Console.WriteLine("Data is Feching By System");
      await Task.Delay(3000);
    }
}