using System.Text.Json;
using Lab3;

var carsPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
var bikesPath = Path.Combine(Directory.GetCurrentDirectory(), "bikes.json");

var carsJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "cars.json"));
var bikesJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "bikes.json"));


var cars = JsonSerializer.Deserialize<List<Car>>(carsJson);
var bikes = JsonSerializer.Deserialize<List<Bike>>(bikesJson);

List<Vehicle> Vehicles()
{
    var list = new List<Vehicle>();
    list.AddRange(cars);
    list.AddRange(bikes);
    return list;
}

bool run = true;

do
{
    Console.WriteLine("CAR SHOP");
    Console.WriteLine("[1] Show all, [2] Search by year, [3] Search by model" +
                      " , [4] Search by engine capacity , [5] Add car, [6] Delete vehicle [0] Exit");
    var input = Console.ReadKey().KeyChar;
    
    Console.WriteLine();

    switch (input)
    {
        case '1':
            DisplayVehicleModel();
            break;
        case '2':
            SearchByYear();
            break;
        case '3':
            SearchByModel();
            break;
        case '4':
            SearchByEngineCapacity();
            break;
        case '5':
            AddNewVehicle();
            break;
        case '6':
            DeleteVehicle();
            break;
        case '0':
            run = false;
            break;
        default:
            Console.WriteLine("Invalid menu option");
            break;
    }
}while(run);

Console.WriteLine("Goodbye");

void DisplayVehicleModel()
{
    Console.WriteLine("Our Vehicles:");
    foreach (var vehicle in Vehicles())
    {
        Console.WriteLine(vehicle.Model);
    }
}

void SearchByYear()
{
    Console.Write("Enter year: ");
    var success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        SearchByYear();
        return;
    }

    var vehicles = Vehicles().Where(veh => veh.Year == year);

    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Model: {vehicle.Model}, Year: {vehicle.Year}");
        }
    }
}

void SearchByModel()
{
    Console.Write("Enter model: ");
    
    string? model = Console.ReadLine();
    
    if (string.IsNullOrEmpty(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    
    var vehicles = Vehicles().Where(veh => veh.Model.ToLower() == model.ToLower());
    
    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Model: {vehicle.Model}, Year: {vehicle.Year}");
        }
    }
    
}
void SearchByEngineCapacity()
{
    Console.Write("Enter engine capacity: ");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        SearchByEngineCapacity();
        return;
    }

    var vehicles = Vehicles().Where(veh => veh.EngineCapacity == engineCapacity);

    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Model: {vehicle.Model}, Year: {vehicle.Year}");
        }
    }
}

void DeleteVehicle()
{
    Console.Write("Which vehicle would you like to delete: ");
}

void AddNewVehicle()
{
    Console.Write("B for bike, C for car");
    var input = Console.ReadKey().KeyChar;

    if (input.ToString().ToLower() is not ("b" or "c"))
    {
        Console.WriteLine("Invalid vehicle type");
        return;
    }
    
    Console.WriteLine("Enter engine capacity: ");
    
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);

    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }
    Console.WriteLine("Enter model: ");
    
    string? model = Console.ReadLine();

    if (string.IsNullOrEmpty(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    
    Console.WriteLine("Enter year ");
    
    success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        return;
    }
    

    if (input.ToString().ToLower() == "c")
    {
        foreach (var vehicle in Vehicles())
        {
            int a = 0;
            if (a > vehicle.Id)
            {
                
            }
        }
        var v = new Car(id, engineCapacity, model, year);
        cars.Add(v);
        File.WriteAllText(carsPath, JsonSerializer.Serialize(cars));
        return;
    }
    bikes.Add(new Bike(id, engineCapacity, model, year));
    File.WriteAllText(bikesPath, JsonSerializer.Serialize(bikes));
}
    