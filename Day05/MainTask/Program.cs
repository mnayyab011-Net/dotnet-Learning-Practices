students s1 = new students();
s1.Name = "Ali";
s1.Age = 26;
s1.RN = 10;
students s2 = new students();
s2.Name = "Nayyab";
s2.Age = 23;
s2.RN = 12;
students s3 = new students();
s3.Name = "Muqadas";
s3.Age = 23;
s3.RN = 20;
s1.GetDetails();
Console.WriteLine();
s2.GetDetails();
Console.WriteLine();
s3.GetDetails();
Console.WriteLine();
class students
{
    public string Name;
    public int Age;
    public int RN;

    public void GetDetails()
    {
        Console.WriteLine("Student Name is: " + Name);
        Console.WriteLine("Student Age is: " + Age);
        Console.WriteLine("Student Roll Number is: " + RN);
    }
}