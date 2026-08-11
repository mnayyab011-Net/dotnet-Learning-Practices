Console.WriteLine("Enter your age");
int age = Convert.ToInt32(Console.ReadLine());
if(age is int)
{
    Console.WriteLine("Age is Int");
}
else
{
    Console.WriteLine("Age is not Int");
}