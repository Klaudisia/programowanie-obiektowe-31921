using Lab3;

bool run = true;

do
{
    Console.WriteLine("CAR SHOP");
    Console.WriteLine("[1] Show all, [2] Search by year, [3] Search by model" +
                      " , [4] Search by engine capacity , [5] Add car, [0] Exit");
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
    foreach (var vehicle in Database.Vehicles)
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

    var vehicles = Database.Vehicles.Where(veh => veh.Year == year);

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
    
    var vehicles = Database.Vehicles.Where(veh => veh.Model.ToLower() == model.ToLower());
    
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

    var vehicles = Database.Vehicles.Where(veh => veh.EngineCapacity == engineCapacity);

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

    Vehicle v;

    if (input.ToString().ToLower() == "c")
    {
        v = new Car(engineCapacity, model, year);
    }
    else
    {
        v = new Bike(engineCapacity, model, year);
    }
    
    Database.Vehicles.Add(v);
}
    