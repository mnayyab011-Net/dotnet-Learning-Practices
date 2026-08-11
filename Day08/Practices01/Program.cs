try
{
    Console.WriteLine("Enter your Age");
    int Age=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(Age);
}
catch (FormatException)
{

    Console.WriteLine("Please Enter Number Only");
}
