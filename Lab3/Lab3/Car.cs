namespace Lab3;

public class Car : Vehicle
{
    public Car(int id, double engineCapacity, string model, int year) : base(id, engineCapacity, model, year)
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