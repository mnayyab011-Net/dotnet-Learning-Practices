Console.WriteLine("Enter first number:");
int Firstnumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter second number:");
int Secondnumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Addition: " + (Firstnumber + Secondnumber));
Console.WriteLine("Subtraction: " + (Firstnumber - Secondnumber));
Console.WriteLine("Multiplication: " + (Firstnumber * Secondnumber));
if (Firstnumber == 0)
{
    Console.WriteLine("Can't divide ");
}
else
{
    Console.WriteLine("Division: " + (Firstnumber / Secondnumber));
    Console.WriteLine("Remainder: " + (Firstnumber % Secondnumber));
}