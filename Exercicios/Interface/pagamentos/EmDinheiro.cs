using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.pagamentos
{
    public class EmDinheiro : IPagamento
    {
        public void RealizarPagamento(float valor)
        {
            Console.WriteLine($"{valor} foi pago em dinheiro.");
        }
    }
}