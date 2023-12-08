using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia
{
    public class Trainer : Person
    {
        private string cref;
        public string Cref
        {
            get { return cref; }
            private set { }
        }  

        public Trainer(string name, DateTime birthDate, string cpf, string cref) : base(name, birthDate, cpf)
        {
            this.cref = cref;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendLine("CREF: " + cref);
            
            return sb.ToString();
        }
    }
}