int number=5;
int attempt=0;
int gnumber=0;
while (number != gnumber && attempt<3)
{
  Console.WriteLine("Enter the number:");
 gnumber = Convert.ToInt32(Console.ReadLine());
 attempt++;
   if (gnumber == number)
 {
  Console.WriteLine("you guess correct number");
  break;
 }
 else if (gnumber > number)
 {
  Console.WriteLine("Number is graeter");
 }
 else 
 {
    Console.WriteLine("Enter number is low ");
  }
}
  if (number != gnumber)
{
  Console.WriteLine("Maximum attempt");
  Console.WriteLine("The correct number was: " + number);
}

