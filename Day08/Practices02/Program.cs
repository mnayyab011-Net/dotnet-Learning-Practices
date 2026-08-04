try
{
    Console.WriteLine("Enter your first Number");
    int a=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Second Number");
    int b=Convert.ToInt32(Console.ReadLine());
    int Result=a/b;
    Console.WriteLine(Result);
}
catch (DivideByZeroException)
{
  Console.WriteLine("Number Can't Divided by Zero");
}
catch (FormatException)
{
    Console.WriteLine("Please Enter Number Only");
}