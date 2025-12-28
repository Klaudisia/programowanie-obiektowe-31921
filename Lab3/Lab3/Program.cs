using System.Text.Json;
using Lab3; 

var carsPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
var bikesPath = Path.Combine(Directory.GetCurrentDirectory(), "bikes.json");

if (!File.Exists(carsPath)) File.WriteAllText(carsPath, "[]");
if (!File.Exists(bikesPath)) File.WriteAllText(bikesPath, "[]");

var carsJson = File.ReadAllText(carsPath);
var bikesJson = File.ReadAllText(bikesPath);

var cars = JsonSerializer.Deserialize<List<Car>>(carsJson) ?? new List<Car>();
var bikes = JsonSerializer.Deserialize<List<Bike>>(bikesJson) ?? new List<Bike>();

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
    Console.WriteLine("\n--- CAR SHOP ---");
    Console.WriteLine("[1] Show all, [2] Search by year, [3] Search by model" +
                      " , [4] Search by engine capacity , [5] Add car/bike, [6] Delete vehicle, [7] Modify Vehicle, [0] Exit");
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
        case '7':
            ModifyVehicle();
            break;
        case '0':
            run = false;
            break;
        default:
            Console.WriteLine("Invalid menu option");
            break;
    }
} while(run);

Console.WriteLine("Goodbye");

void DisplayVehicleModel()
{
    Console.WriteLine("Our Vehicles:");
    foreach (var vehicle in Vehicles())
    {
        Console.WriteLine($"[ID: {vehicle.Id}] {vehicle.Model} ({vehicle.Year})");
    }
}

void SearchByYear()
{
    Console.Write("Enter year: ");
    var success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
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
            Console.WriteLine($"[ID: {vehicle.Id}] Model: {vehicle.Model}, Year: {vehicle.Year}");
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
    
    var vehicles = Vehicles().Where(veh => veh.Model.ToLower().Contains(model.ToLower())); 
    
    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"[ID: {vehicle.Id}] Model: {vehicle.Model}, Year: {vehicle.Year}");
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
            Console.WriteLine($"[ID: {vehicle.Id}] Model: {vehicle.Model}, Year: {vehicle.Year}");
        }
    }
}

void DeleteVehicle()
{
    Console.Write("Enter vehicle ID to delete: ");
    var success = int.TryParse(Console.ReadLine(), out int idToDelete);

    if (!success)
    {
        Console.WriteLine("Invalid ID format.");
        return;
    }


    var carToDelete = cars.FirstOrDefault(c => c.Id == idToDelete);
    if (carToDelete != null)
    {
        cars.Remove(carToDelete);
        File.WriteAllText(carsPath, JsonSerializer.Serialize(cars));
        Console.WriteLine("Car deleted successfully.");
        return;
    }


    var bikeToDelete = bikes.FirstOrDefault(b => b.Id == idToDelete);
    if (bikeToDelete != null)
    {
        bikes.Remove(bikeToDelete);
        File.WriteAllText(bikesPath, JsonSerializer.Serialize(bikes));
        Console.WriteLine("Bike deleted successfully.");
        return;
    }

    Console.WriteLine("Vehicle with this ID not found.");
}

void ModifyVehicle()
{
    Console.Write("Enter vehicle ID: ");
    var success = int.TryParse(Console.ReadLine(), out int idToModify);
    if (!success)
    {
        Console.WriteLine("Invalid ID format.");
        return;
    }
    
    var carToModify = cars.FirstOrDefault(c => c.Id == idToModify);
    if (carToModify != null)
    {
        Console.Write("Enter vehicle model: ");
        var model = Console.ReadLine();
        carToModify.Model = model;
        Console.Write("Enter engine capacity: ");
        var engineCapacity = double.Parse(Console.ReadLine());
        carToModify.EngineCapacity = engineCapacity;
        Console.Write("Enter year: ");
        var year = int.Parse(Console.ReadLine());
        carToModify.Year = year;
        Console.WriteLine("Vehicle has been modified successfully.");
        return;
    }
    var bikeToModify = bikes.FirstOrDefault(b => b.Id == idToModify);
    if (bikeToModify != null)
    {
        Console.Write("Enter vehicle model: ");
        var model = Console.ReadLine();
        bikeToModify.Model = model;
        Console.Write("Enter engine capacity: ");
        var engineCapacity = double.Parse(Console.ReadLine());
        bikeToModify.EngineCapacity = engineCapacity;
        Console.Write("Enter year: ");
        var year = int.Parse(Console.ReadLine());
        bikeToModify.Year = year;
        Console.WriteLine("Vehicle has been modified successfully.");
        return;
    }
    
    Console.WriteLine("Vehicle with this ID not found.");
}

void AddNewVehicle()
{
    Console.WriteLine("Press 'B' for bike, 'C' for car");
    var keyInfo = Console.ReadKey();
    var input = keyInfo.KeyChar.ToString().ToLower();
    Console.WriteLine(); 

    if (input is not ("b" or "c"))
    {
        Console.WriteLine("Invalid vehicle type");
        return;
    }
    
    Console.Write("Enter engine capacity: ");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }

    Console.Write("Enter model: ");
    string? model = Console.ReadLine();
    if (string.IsNullOrEmpty(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    
    Console.Write("Enter year: ");
    success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        return;
    }
    

    int newId = 1;
    var currentVehicles = Vehicles();
    if (currentVehicles.Any())
    {
        newId = currentVehicles.Max(v => v.Id) + 1;
    }

    if (input == "c")
    {
        var v = new Car(newId, engineCapacity, model, year);
        cars.Add(v);
        File.WriteAllText(carsPath, JsonSerializer.Serialize(cars));
        Console.WriteLine($"Added Car with ID: {newId}");
    }
    else
    {
        var b = new Bike(newId, engineCapacity, model, year);
        bikes.Add(b);
        File.WriteAllText(bikesPath, JsonSerializer.Serialize(bikes));
        Console.WriteLine($"Added Bike with ID: {newId}");
    }
}