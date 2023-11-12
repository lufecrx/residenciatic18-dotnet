# Questao 02 - Tipos de Dados
## Problema: 
Quais s�o os tipos de dados num�ricos inteiros dispon�veis no .NET? D� exemplos de uso para cada um deles atrav�s de exemplos.

## Resposta:
No .NET os n�meros inteiros s�o definidos por 3 tipos que s�o: int, long e short. O int � comumente usado para n�meros considerados razoav�is. O long � utilizado para n�meros maiores e o short para n�meros menores, como seus nomes sugerem.

Todos os 3 tipos acima descritos contam com os tipos unsigned que significa um tipo sem sinal. Ent�o, enquanto o int aceita valores negativos, o uint aceita apenas valores positivos. O mesmo acontece com o long, ulong, short e ushort.

Exemplos de uso para cada um deles:
- short e ushort
```cs
short populationChange = -1500;
```
populationChange representa a mudan�a na popula��o, usando short para lidar com n�meros inteiros pequenos, como varia��es populacionais
```cs
ushort itemCount = 5000;
```
itemCount indica a quantidade de itens em estoque, usando ushort porque n�o pode ser negativo e espera-se que seja um n�mero relativamente pequeno.
- int e uint
```cs
int bankBalance = -2000000;
```
bankBalance armazena o saldo banc�rio, usando int para valores monet�rios que podem ser positivos ou negativos e que podem abranger uma faixa razo�vel.
```cs
uint totalVotes = 300000000;
```
totalVotes guarda o n�mero total de votos em uma elei��o, usando uint porque n�o pode ser negativo e � uma quantidade significativa.
- long e ulong
```cs
long nationalDebt = -123456789012345;
```
nationalDebt representa a d�vida nacional, usando long para lidar com valores grandes, positivos ou negativos.
```cs
ulong galaxiesInObservableUniverse = 100000000000;
```
galaxiesInObservableUniverse armazena o n�mero de gal�xias no universo observ�vel, usando ulong devido � magnitude do n�mero e ao fato de que n�o pode ser negativo.
