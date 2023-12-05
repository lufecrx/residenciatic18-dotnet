using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.pagamentos
{
    public class TransferenciaBancaria : IPagamento
    {
        public void RealizarPagamento(float valor)
        {
            Console.WriteLine($"O valor de {valor} foi transferido com sucesso.");
        }
    }
}