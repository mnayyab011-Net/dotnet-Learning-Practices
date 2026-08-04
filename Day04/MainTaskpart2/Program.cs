List<int> numbers = new List<int>()
{
 15, 25, 35, 45, 55
};
Findmax(numbers);
Findmin(numbers);
Findaverage(numbers);
void Findmax(List<int> numbers)
{
int max = numbers[0];
for (int i = 1; i < numbers.Count; i++)
{
if (numbers[i] > max)
{
max = numbers[i];
}
}
Console.WriteLine("Maximum = " + max);
}
void Findmin(List<int> numbers)
{
int min = numbers[0];
for (int i = 1; i < numbers.Count; i++)
    {
         if (numbers[i] < min)
        {
            min = numbers[i];
        }
    }
 Console.WriteLine("Minimum = " + min);
}
void Findaverage(List<int> numbers)
{
int total = 0;
for (int i = 0; i < numbers.Count; i++)
{
total = total + numbers[i];
}
double average = (double)total / numbers.Count;
Console.WriteLine("Average = " + average);
}