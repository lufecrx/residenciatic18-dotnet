#region Tuple Exercises 01
(string, int) GetAge (string name, DateTime born)
{ 
    int age = DateTime.Now.Year - born.Year;
    if (DateTime.Now.DayOfYear < born.DayOfYear)
        age--;
    return (name, age);
}

Console.WriteLine("Nome: ");
string name = Console.ReadLine();

Console.WriteLine("Data de nascimento: ");
DateTime birthDate;

if(DateTime.TryParse(Console.ReadLine(), out birthDate)){
    var getData = GetAge(name, birthDate);
    Console.WriteLine($"{getData.Item1} tem {getData.Item2} anos.");    
}

#endregion