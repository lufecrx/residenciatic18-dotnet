#region Tuple Exercises
// (string, int) GetAge (string name, DateTime born)
// { 
//     int age = DateTime.Now.Year - born.Year;
//     if (DateTime.Now.DayOfYear < born.DayOfYear)
//         age--;
//     return (name, age);
// }

// Console.WriteLine("Nome: ");
// string name = Console.ReadLine();

// Console.WriteLine("Data de nascimento: ");
// DateTime birthDate;

// if(DateTime.TryParse(Console.ReadLine(), out birthDate)){
//     var getData = GetAge(name, birthDate);
//     Console.WriteLine($"{getData.Item1} tem {getData.Item2} anos.");    
// }

#endregion

#region Lambda Exercises

// Func<string, DateTime, (string, int)> GetAge = (name, birthDate) => {
//     int age = DateTime.Now.Year - birthDate.Year;
//     if(DateTime.Now.DayOfYear < birthDate.DayOfYear)
//         age--;
//     return (name, age);
// };

// Console.WriteLine("Nome: ");
// string name = Console.ReadLine();

// Console.WriteLine("Data de nascimento: ");
// DateTime birthDate;

// if(DateTime.TryParse(Console.ReadLine(), out birthDate)){
//     var getData = GetAge(name, birthDate);
//     Console.WriteLine($"{getData.Item1} tem {getData.Item2} anos.");    
// }

// string[] names = { "Luiz", "Fulano", "Ciclano", "Beltrano" };
// char letterSearched = 'c';

// Console.WriteLine($"Todos nomes: {string.Join(", ", names)}");
// Console.WriteLine($"Letra pesquisada: {letterSearched}");

// IEnumerable<string> result = names
//     .Where(name => name.StartsWith(letterSearched.ToString(), StringComparison.OrdinalIgnoreCase));

// Console.WriteLine(string.Join(", ", result));

#endregion

#region Debugging Exercies
// Func<int, int, int> sum = (x, y) => x + y;

// Console.WriteLine(sum(10, 20));

// Action<String> greet = name =>
// {
//     string greeting = $"Hello, {name}";
//     Console.WriteLine(greeting);
// };

// string person = Console.ReadLine() ?? "";
// greet(person);

#endregion

#region Exception Exercises
(string, int) GetAge (string name, DateTime born)
{ 
    int age = DateTime.Now.Year - born.Year;
    if (DateTime.Now.DayOfYear < born.DayOfYear)
        age--;
    return (name, age);
}

Console.WriteLine("Nome: ");
string name = Console.ReadLine();
// Tupla (string, DateTime)
(string, int) getData = ("", 0);
try
{
    Console.WriteLine("Data de nascimento: ");
    DateTime birthDate = DateTime.Parse(Console.ReadLine());
    getData = GetAge(name, birthDate);
}
catch (FormatException ex)
{
    Console.WriteLine($"Insira uma data de nascimento com o formato correto. (dd/mm/aaaa)\nErro: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
Console.WriteLine($"{getData.Item1} tem {getData.Item2} anos.");

#endregion