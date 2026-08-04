car car = new car();
car.Start();
car.Preparing();
class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle is Starting");
    }
}
class car : Vehicle
{
    public void Preparing()
    {
        Console.WriteLine("Car is Preparing");
    }
}