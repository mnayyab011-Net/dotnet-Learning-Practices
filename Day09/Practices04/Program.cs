class Fruits
{
}
class Mango : Fruits
{    public int Price;
    public Mango(int price)
    {
        Price = price;
    }
}
class Apple : Fruits
{
    public int Price;
    public Apple(int price)
    {
        Price = price;
    }
}
class Banana : Fruits
{
    public int Price;
    public Banana(int price)
    {
        Price = price;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fruits fruit = new Mango(2200);
        string result = fruit switch
        {
            Mango m => $"Mango price is {m.Price}",
            Apple a => $"Apple price is {a.Price}",
            Banana b => $"Banana price is {b.Price}",
            _ => "Unknown"
        };
        Console.WriteLine(result);
    }
}