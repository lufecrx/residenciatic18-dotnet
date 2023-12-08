using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia
{
    public class GymManagement
    {
        private List<Trainer> trainers;
        private List<Customer> customers;

        public GymManagement()
        {
            trainers = new List<Trainer>();
            customers = new List<Customer>();
        }

        // Adicionar e remover treinadores e clientes de suas listas
        public void AddTrainer(Trainer trainer)
        {
            trainers.Add(trainer);
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void RemoveTrainer(Trainer trainer)
        {
            trainers.Remove(trainer);
        }

        public void RemoveCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        public void CreateTrainer()
        {
            try
            {
                Console.WriteLine("Insira os detalhes do treinador.");
                Console.Write("Nome: ");
                string? name = Console.ReadLine();
                IsNullOrWhiteSpace(name);

                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                ValidateBirthDate(birthDate);

                Console.Write("CPF: ");
                string? cpf = Console.ReadLine();
                ValidateCPF(cpf);
                if (trainers.Any(t => t.Cpf == cpf))
                    throw new ArgumentException("CPF já existente.");

                Console.Write("CREF: ");
                string? cref = Console.ReadLine();
                IsNullOrWhiteSpace(cref);
                if (trainers.Any(t => t.Cref == cref))
                    throw new ArgumentException("CREF já existente.");

                var trainer = new Trainer(name, birthDate, cpf, cref);
                AddTrainer(trainer);
                Console.WriteLine("Treinador criado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Data de nascimento inválida.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        public void CreateCustomer()
        {
            try
            {
                Console.WriteLine("Insira os detalhes do cliente.");

                Console.Write("Nome: ");
                string? name = Console.ReadLine();
                IsNullOrWhiteSpace(name);

                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                ValidateBirthDate(birthDate);

                Console.Write("CPF: ");
                string? cpf = Console.ReadLine();
                ValidateCPF(cpf);
                if (customers.Any(c => c.Cpf == cpf))
                    throw new ArgumentException("CPF já existente.");

                Console.Write("Altura (em cm): ");
                int height;
                if (int.TryParse(Console.ReadLine(), out height))
                    throw new FormatException("Altura inválida, insira seu tamanho em centímetros com um número inteiro.");
                if (height <= 0)
                    throw new ArgumentOutOfRangeException("Altura deve ser maior que zero.");

                Console.Write("Peso (em kg): ");
                float weight;
                if (!float.TryParse(Console.ReadLine(), out weight))
                    throw new FormatException("Insira seu peso em quilos com um número decimal.");
                if (weight <= 0)
                    throw new ArgumentOutOfRangeException("Peso deve ser maior que zero.");

                var customer = new Customer(name, birthDate, cpf, height, weight);
                AddCustomer(customer);
                Console.WriteLine("Cliente criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Relatórios

        // Treinadores com idade entre dois valores
        public void PrintTrainersByAgeRange()
        {
            try
            {
                int minimumAge, maximumAge;
                Console.Write("Insira a idade miníma: ");
                if (!int.TryParse(Console.ReadLine(), out minimumAge))
                    throw new FormatException("Idade miníma deve ser um valor inteiro.");
                if (minimumAge < 0)
                    throw new FormatException("Idade miníma deve ser maior que zero.");

                Console.Write("Insira a idade máxima: ");
                if (!int.TryParse(Console.ReadLine(), out maximumAge))
                    throw new FormatException("Idade máxima deve ser um valor inteiro.");
                if (maximumAge < 0)
                    throw new FormatException("Idade máxima deve ser maior que zero.");
                if (maximumAge < minimumAge)
                    throw new FormatException("Idade máxima deve ser maior ou igual a idade miníma.");

                IEnumerable<Customer> customersBetweenTheAges =
                                        from customer in customers
                                        where (customer.Age >= minimumAge) && (customer.Age <= maximumAge)
                                        select customer;

                Console.WriteLine();
                foreach (Customer customer in customersBetweenTheAges)
                    Console.WriteLine(customer);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Clientes com idade entre dois valores
        public void PrintCustomersByAgeRange()
        {
            try
            {
                int minimumAge, maximumAge;
                Console.Write("Insira a idade miníma: ");
                if (!int.TryParse(Console.ReadLine(), out minimumAge))
                    throw new FormatException("Idade miníma deve ser um valor inteiro.");
                if (minimumAge < 0)
                    throw new FormatException("Idade miníma deve ser maior que zero.");

                Console.Write("Insira a idade máxima: ");
                if (!int.TryParse(Console.ReadLine(), out maximumAge))
                    throw new FormatException("Idade máxima deve ser um valor inteiro.");
                if (maximumAge < 0)
                    throw new FormatException("Idade máxima deve ser maior que zero.");
                if (maximumAge < minimumAge)
                    throw new FormatException("Idade máxima deve ser maior ou igual a idade miníma.");

                IEnumerable<Trainer> trainersBetweenTheAges =
                                        from trainer in trainers
                                        where trainer.Age >= minimumAge
                                        where trainer.Age <= maximumAge
                                        select trainer;

                Console.WriteLine();
                foreach (Trainer trainer in trainersBetweenTheAges)
                    Console.WriteLine(trainer);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Clientes com IMC maior que o valor informado
        public void PrintCustomersByIMC()
        {
            try
            {
                Console.Write("Insira o valor mínimo do IMC: ");
                float imc;
                if (!float.TryParse(Console.ReadLine(), out imc))
                    throw new FormatException("IMC deve ser um valor decimal.");
                if (imc <= 0)
                    throw new FormatException("IMC deve ser maior que zero.");

                // Imprimir em ordem crescente, pelo IMC
                customers.Where(c => c.IMC > imc)
                         .OrderByDescending(c => c.IMC).ToList().ForEach(c => Console.WriteLine(c + "\n"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Clientes em ordem alfabética
        public void PrintCustomersAlphabetically()
        {
            try
            {
                customers.OrderBy(c => c.Name).ToList().ForEach(c => Console.WriteLine(c + "\n"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Clientes do mais velho para o mais novo
        public void PrintCustomersDescendingByAge()
        {
            try
            {
                customers.OrderByDescending(c => c.Age).ToList().ForEach(c => Console.WriteLine(c + "\n"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Treinadores e clientes aniversariantes do mês informado
        public void PrintBirthdays()
        {
            try
            {
                Console.WriteLine("Insira o mês: ");
                int month;
                if (!int.TryParse(Console.ReadLine(), out month))
                    throw new ArgumentException("Mês deve ser um valor inteiro.");

                trainers.Where(t => t.BirthDate.Month == month).ToList().ForEach(t => Console.WriteLine(t + "\n"));
                customers.Where(c => c.BirthDate.Month == month).ToList().ForEach(c => Console.WriteLine(c + "\n"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        // Validar dados de entrada
        public void IsNullOrWhiteSpace(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O campo não pode estar vazio ou com espaço em branco");
        }

        public void ValidateCPF(string? cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                throw new ArgumentException("O cpf deve conter pelo menos 11 digitos");
            }
        }

        public void ValidateBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento deve ser anterior a data atual.");
            }
            // Não é permitido menores de 13 anos
            if (birthDate.AddYears(13) > DateTime.Now)
            {
                throw new ArgumentException("A pessoa deve ter pelo menos 13 anos para treinar na academia.");
            }
        }
    }

            // Retornar o treinador pelo seu CPF
        // public Trainer? GetTrainerByCPF(string? cpf)
        // {
        //     try
        //     {
        //         if (trainers.Any(t => t.Cpf == cpf))
        //             return trainers.FirstOrDefault(t => t.Cpf == cpf);
        //         else
        //             throw new ArgumentNullException($"Treinador com CPF {cpf} não encontrado.");
        //     }
        //     catch (ArgumentNullException ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         return null;
        //     }
        // }

        // Retornar o cliente pelo seu CPF
        // public Customer? GetCustomerByCPF(string cpf)
        // {
        //     try
        //     {
        //         if (customers.Any(c => c.Cpf == cpf))
        //             return customers.FirstOrDefault(c => c.Cpf == cpf);
        //         else
        //             throw new ArgumentNullException($"Cliente com CPF {cpf} não encontrado.");
        //     }
        //     catch (ArgumentNullException ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         return null;
        //     }
        // }

                // public Trainer? GetTrainerByCREF(string cref)
        // {
        //     try
        //     {
        //         if (trainers.Any(t => t.Cref == cref))
        //             return trainers.FirstOrDefault(t => t.Cref == cref);
        //         else
        //             throw new ArgumentNullException($"Treinador com CREF {cref} não encontrado.");
        //     }
        //     catch (ArgumentNullException ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         return null;
        //     }
        // }
}

