// // Example 1
//
// const int requiredAge = 14;
// const string accessDenied = "Musisz mieć 14 lat.";
// const string accessAllowed = "Witamy w naszym sklepie";
// const string access14 = "Witamy w naszym sklepie, ale nie kupisz i nie zarejestrujesz karty SIM";
// int age = 19;
//
// do
// {
//     Console.WriteLine("Podaj swój wiek: ");
//
//     string input = Console.ReadLine();
//
//     bool success = int.TryParse(input, out age);
//
//     if (!success)
//     {
//         Console.WriteLine("Podaj poprawną wartość!");
//     }
//     else
//     {
//         if (age < requiredAge)
//         {
//             Console.WriteLine(accessDenied);
//         }
//         else if (age > requiredAge && age < 18)
//         {
//             Console.WriteLine(access14);
//         }
//         else
//         {
//             Console.WriteLine(accessAllowed);
//         }
//     }
// } while (age < requiredAge);

// Example 2

// var names = new[] { "Artur", "Alicja", "Michał", "Gosia" };
//
// for (int i = 0; i < names.Length; i++)
// {
//     Console.WriteLine(names[i]);
// }
//
// foreach (var name in names)
// {
//     Console.WriteLine(name);
// }

//zadanie 1.1

// string password;
//
// do
// {
//     Console.Write("Proszę podaj hasło...");
//     password = Console.ReadLine();
// }while(password != "admin123");
//
// Console.WriteLine("Zalogowano pomyślnie!");

//zadanie 1.2

// int liczba;
//
// do
// {
//     Console.Write("Proszę podaj liczbę większą od 0");
//     liczba = int.Parse(Console.ReadLine());
// }while(liczba <= 0);
//
// //zadanie 1.3
//
// string[] miasta = { "Poznań", "Pniewy", "Lwówek", "Kraków", "Wrocław" };
// foreach (string miasto in miasta)
// {
//     Console.WriteLine($"Miasto: {miasto}");
// }

