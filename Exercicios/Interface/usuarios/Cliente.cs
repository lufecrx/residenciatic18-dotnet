using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.usuarios
{
    public class Cliente
    {
        public string Nome { get; set;}
        public string Email { get; set;}

        public void RealizarPagamento(IPagamento tipoDePagamento)
        {
            Console.WriteLine("Qual valor que vai ser realizado o pagamento?");
            float pagamento;
            if(float.TryParse(Console.ReadLine(), out pagamento)) 
            {
                tipoDePagamento.RealizarPagamento(pagamento);
            }
            else 
            {
                throw new InvalidCastException();
            }
        }
    }
}