using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Academia
{
    public class Customer : Person
    {
        private int height;
        private float weight;

        public int Height
        {
            get { return height; }
            private set { }
        }

        public float Weight
        {
            get { return weight; }
            private set { }
        }

        public float IMC
        {
            get 
            {
                return weight / ((height / 100) * (height / 100));
            }
        }


        public Customer(string name, DateTime birthDate, string cpf, int height, float weight) : base(name, birthDate, cpf)
        {
            this.height = height;
            this.weight = weight;            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
           
            sb.AppendLine(base.ToString());
            sb.AppendLine("Altura: " + height);
            sb.AppendLine("Peso: " + weight);

            return sb.ToString();
        }
    }
}