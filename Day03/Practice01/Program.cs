Console.WriteLine("Enter Garde between A/B/C/D/E");
char grade = Convert.ToChar(Console.ReadLine());
switch (grade)
{
    case 'A':
    Console.WriteLine("Excellent");
    break;
    case 'B':
    Console.WriteLine("Good");
    break;
    case 'C':
    Console.WriteLine("AVG");
    break;
    case 'D':
    Console.WriteLine("LOW");
    break;
    case 'E':
    Console.WriteLine("Poor");
    break;
    default:
    Console.WriteLine("Fail");
    break;
}



