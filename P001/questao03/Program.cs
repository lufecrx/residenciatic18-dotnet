double myDouble = 23.75;

int numeroConvertido = Convert.ToInt32(myDouble);
Console.WriteLine($"Usando Convert: {numeroConvertido}");
// 24, o valor foi arrendodado para cima

int numeroConvertidoCast = (int)myDouble;
Console.WriteLine($"Usando cast: {numeroConvertidoCast}");
// 23, a parte fracionária foi truncada

Console.ReadKey();

