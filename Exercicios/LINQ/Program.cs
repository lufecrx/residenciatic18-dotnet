#region Tuple Exercises 01
(string, int) GetAge (string name, DateTime born)
{ 
    int age = DateTime.Now.Year - born.Year;
    if (DateTime.Now.DayOfYear < born.DayOfYear)
        age--;
    return (name, age);
}

var getData = GetAge("Luiz", new DateTime(2003, 7, 6));
Console.WriteLine($"{getData.Item1} tem {getData.Item2} anos.");
#endregion