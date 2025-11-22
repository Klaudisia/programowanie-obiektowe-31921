namespace Lab3;

public class Database
{
    public static List<Vehicle> Vehicles { get; set; } = 
    [
        new Bike(0.8, "Yamaha", 2025),
        new Bike(0.5, "Kawasaki", 2023),
        new Car(2.0, "VW", 2006),
        new Car(1.0, "Volvo", 2003)
    ];
}