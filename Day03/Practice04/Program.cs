Console.WriteLine("Enter your age");
int age=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Do you have Cnic:");
string cnic = Convert.ToString(Console.ReadLine());
if (age>=18)
{
    if (cnic == "yes")
    {
        Console.WriteLine("Your are eligible");
    }
}
