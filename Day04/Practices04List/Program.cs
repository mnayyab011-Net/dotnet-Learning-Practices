List<int> marks = new List<int>();
for (int i = 0; i < 5; i++)
{
Console.Write("Enter Marks " + (i + 1));
int mark = Convert.ToInt32(Console.ReadLine());
marks.Add(mark);
}
Console.WriteLine();
int total = 0;
int max = marks[0];
for (int i = 0; i < marks.Count; i++)
{
Console.WriteLine("Student " + (i + 1) + " Marks  " + marks[i]);
total = total + marks[i];
if (marks[i] > max)
{
 max = marks[i];
 }
}
Console.WriteLine("Total = " + total);
Console.WriteLine("max = " + max);