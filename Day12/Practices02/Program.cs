using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("Press Download Button");
        Task clickTask = MakeDownloadAsync();
        Console.WriteLine("Open another website and scroll it.");
        await clickTask;
        Console.WriteLine("File download completed.");
    }

    static async Task MakeDownloadAsync()
    {
        Console.WriteLine("Start downloading file...");
        await Task.Delay(3000);
        Console.WriteLine("Download completed.");
    }
}