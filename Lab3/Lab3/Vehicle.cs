namespace Lab3;

public abstract class Vehicle
{
    private int id;
    public double EngineCapacity { get; protected set; }
    private string model;
    private int year;
    
    public string Model => model;

    public int Year
    {
        get { return year; }
    }

    public Vehicle(int id, double engineCapacity, string model, int year)
    {
        this.id = id;
        EngineCapacity = engineCapacity;
        this.model = model;
        this.year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }
    
    public abstract void Test();
}