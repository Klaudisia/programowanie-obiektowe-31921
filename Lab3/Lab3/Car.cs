namespace Lab3;

public class Car : Vehicle
{
    public Car(double engineCapacity, string model, int year) : base(engineCapacity, model, year)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Car started");
    }

    public override void Test()
    {
        Console.WriteLine("Car test");
    }

    public void ShowMe()
    {
        Console.WriteLine($"Model: {Model}, Year: {Year}");
    }
}