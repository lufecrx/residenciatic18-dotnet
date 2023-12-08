using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Interface.pagamentos
{
    public class CartaoCredito : IPagamento
    {
        float Conta { get; set; }

        public void RealizarPagamento(float valor)
        {
           Console.WriteLine($"O pagamento de {valor} no cartão de crédito foi realizado com sucesso.");
        }
    }
}