
interface IAnimal
{
    void Sound();
}
class Dog : IAnimal
{
    public void Sound()
    {
        Console.WriteLine("Dog says: Bark");
    }
}
class Cat : IAnimal
{
    public void Sound()
    {
        Console.WriteLine("Cat says: Meow");
    }
}
class Cow : IAnimal
{
    public void Sound()
    {
        Console.WriteLine("Cow says: Moo");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.Sound();
        Cat cat = new Cat();
        cat.Sound();
        Cow cow = new Cow();
        cow.Sound();
    }
}