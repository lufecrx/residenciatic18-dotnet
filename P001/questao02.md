# Questao 02 - Tipos de Dados
## Problema: 
Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê exemplos de uso para cada um deles através de exemplos.

## Resposta:
No .NET os números inteiros são definidos por 3 tipos que são: int, long e short. O int é comumente usado para números considerados razoavéis. O long é utilizado para números maiores e o short para números menores, como seus nomes sugerem.

Todos os 3 tipos acima descritos contam com os tipos unsigned que significa um tipo sem sinal. Então, enquanto o int aceita valores negativos, o uint aceita apenas valores positivos. O mesmo acontece com o long, ulong, short e ushort.

Exemplos de uso para cada um deles:
- short e ushort
```cs
short populationChange = -1500;
```
populationChange representa a mudança na população, usando short para lidar com números inteiros pequenos, como variações populacionais
```cs
ushort itemCount = 5000;
```
itemCount indica a quantidade de itens em estoque, usando ushort porque não pode ser negativo e espera-se que seja um número relativamente pequeno.
- int e uint
```cs
int bankBalance = -2000000;
```
bankBalance armazena o saldo bancário, usando int para valores monetários que podem ser positivos ou negativos e que podem abranger uma faixa razoável.
```cs
uint totalVotes = 300000000;
```
totalVotes guarda o número total de votos em uma eleição, usando uint porque não pode ser negativo e é uma quantidade significativa.
- long e ulong
```cs
long nationalDebt = -123456789012345;
```
nationalDebt representa a dívida nacional, usando long para lidar com valores grandes, positivos ou negativos.
```cs
ulong galaxiesInObservableUniverse = 100000000000;
```
galaxiesInObservableUniverse armazena o número de galáxias no universo observável, usando ulong devido à magnitude do número e ao fato de que não pode ser negativo.
