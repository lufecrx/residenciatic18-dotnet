#region Exercises
Console.WriteLine("\nNúmeros divisíveis por 3 ou por 4 entre 0 e 30:");
for (int i = 0; i <= 30; i++)
{
    if ((i % 3 == 0) || (i % 4 == 0))
        Console.WriteLine(i);
}

Console.WriteLine("\nA série de Fibonacci até passar de 100:");
int x = 1, y = 0, z = 0;
for (int i = 0; (x + y) < 100; i++)
{
    z = x + y;
    Console.WriteLine(z);
    y = x;
    x = z;
}

Console.WriteLine("\nTabela até o nível 8:");
for (int n = 1; n <= 8; n++)
{
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{n * i} ");
    }

    Console.WriteLine();
}
#endregion