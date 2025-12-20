namespace Lab3;

public class Bike : Vehicle
{
    public Bike(int id, double engineCapacity, string model, int year) : base(id,engineCapacity, model, year)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Bike Started");
    }

    public override void Test()
    {
        Console.WriteLine("Bike Test");
    }
}