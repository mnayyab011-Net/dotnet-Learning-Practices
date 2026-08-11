
class vehical
{
}
class car : vehical
{
    public int Seats = 5;
}
class bike : vehical
{
    public int Wheel = 2;
}
class truck : vehical
{
    public int capacity = 50;
}
class Program
{    static void Main(string[] args)
    {
        vehical vel = new bike();
        string result = vel switch
        {
            car { Seats: 5 } => "Five seats car",
            bike { Wheel: 2 } => "Bike 2 wheel",
            truck { capacity: 50 } => "Truck 50 capacity",
            _ => "Unknown Vehicle"
        };
        Console.WriteLine(result);
    }
}