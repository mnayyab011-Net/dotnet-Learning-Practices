try
{
    Console.Write("Enter Your Age: ");
    int age = Convert.ToInt32(Console.ReadLine());
    if (age < 18)
    {
        throw new Exception("You are not eligible. Age must be 18 or above.");
    }
    Console.WriteLine("You are eligible.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}