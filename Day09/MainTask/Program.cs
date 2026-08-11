
class Shape
{
}
class Circle : Shape
{
    public double Radius;
    public Circle(double radius)
    {
        Radius = radius;
    }
}
class Square : Shape
{
    public double Sides;
    public Square(double sides)
    {
        Sides = sides;
    }
}
class Triangle : Shape
{    public double Base;
    public double Height;
    public Triangle(double b, double h)
    {
        Base = b;
        Height = h;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Shape shape = new Circle(5);
        if (shape is Circle circle)
        {
            Console.WriteLine("Circle");
            Console.WriteLine("Radius " + circle.Radius);
        }
        else if (shape is Square square)
        {
            Console.WriteLine("Shape is Square");
            Console.WriteLine("Sides " + square.Sides);
        }
        else if (shape is Triangle triangle)
        {
            Console.WriteLine("Shape is Triangle");
            Console.WriteLine("Base = " + triangle.Base);
            Console.WriteLine("Height = " + triangle.Height);
        }
        else
        {
            Console.WriteLine("Unknown");
        }
        Circle c = shape as Circle;
        if (c != null)
        {
            double circleArea = Math.PI * c.Radius * c.Radius;
            Console.WriteLine("Circle Area = " + circleArea);
        }
        else
        {
            Console.WriteLine("Shape is not Circle");
        }
        double area = shape switch
        {
            Circle x => Math.PI * x.Radius * x.Radius,

            Square x => x.Sides * x.Sides,

            Triangle x => 0.5 * x.Base * x.Height,

            _ => 0
        };
        Console.WriteLine("Area using Switch = " + area);
    }
}
