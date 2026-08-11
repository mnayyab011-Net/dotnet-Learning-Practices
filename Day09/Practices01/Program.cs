class Animal
{
}
class Mammal : Animal
{    public void Eat()
    {
        Console.WriteLine("Eating...");
    }
}
class Cat : Mammal
{
}

class Dog : Mammal
{
}
class Bird : Animal
{
}
class Program
{
static void Main(string[] args)
    {
        Animal a = new Dog();
        if (a is Mammal m)
        {
            m.Eat();
        }
        else
        {
            Console.WriteLine("Mammal not found");
        }
    }
}
