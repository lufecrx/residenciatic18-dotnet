using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Academia
{
    abstract public class Person
    {
        private string? name;
        private DateTime birthDate;
        private string? cpf;

        // Propriedades
        public string Name
        {
            get { return name; }
            private set {}
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            private set { }
        }

        public string Cpf
        {
            get { return Cpf; }
            private set {}
        }

        public int Age 
        {
            get 
            { 
                if (DateTime.Now.Month < BirthDate.Month && DateTime.Now.Day < BirthDate.Day) 
                    return DateTime.Now.Year - BirthDate.Year - 1;
                else 
                    return DateTime.Now.Year - BirthDate.Year;
            }
            private set { }
        }

        public Person(string name, DateTime birthDate, string cpf)  
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Nome: " + name);
            sb.AppendLine("Data de Nascimento: " + birthDate.ToShortDateString());
            sb.AppendLine("CPF: " + cpf);

            return sb.ToString();
        }
    }
}