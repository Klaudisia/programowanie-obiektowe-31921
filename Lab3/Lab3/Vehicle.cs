namespace Lab3;

public abstract class Vehicle
{
    public int Id { get; set; }
    public double EngineCapacity { get; set; }
    public string Model { get; set; } 
    public int Year { get; set; }     
    
    public Vehicle(int id, double engineCapacity, string model, int year)
    {
        Id = id;
        EngineCapacity = engineCapacity;
        Model = model;
        Year = year;
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