int[] sales= new int[6];
for (int i=0; i<sales.Length; i++)
{
    Console.WriteLine("Enter your Sales" + (i+1));
    sales[i]=Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine();
int total = 0;
int max=sales[0];
int min=sales[0];
for (int i=0; i<sales.Length; i++)
{
    Console.WriteLine("Day: " + (i + 1) + " Sales: " + sales[i]);
    total=total+sales[i];
if (sales[i]>max)
{
    max=sales[i];
}
if (sales[i]<min)
{
    min=sales[i];
}
}
Console.WriteLine("Maximum number is:" +max);
Console.WriteLine("Minimum number is:" +min);
Console.WriteLine("Total sales is:" +total);
