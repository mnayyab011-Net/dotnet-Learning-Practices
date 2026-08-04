int[] numbers = { 15, 25, 35, 45, 55 };
Findmax(numbers);
Findmin(numbers);
Findaverage(numbers);
void Findmax(int[] numbers)
{
int max = numbers[0];
for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
 max = numbers[i];}
}
Console.WriteLine("Maximum = " + max);
}
void Findmin(int[] numbers)
{
int min = numbers[0];
for (int i = 1; i < numbers.Length; i++)
{
if (numbers[i] < min){
min = numbers[i];}
}
Console.WriteLine("Minimum = " + min);
}
void Findaverage(int[] numbers)
{
int total = 0;
for (int i = 0; i < numbers.Length; i++)
{
total = total + numbers[i]; }
double average = (double)total / numbers.Length;
Console.WriteLine("Average = " + average);
}