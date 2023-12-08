using Academia;

class Program
{
    GymManagement gymManagement;

    public Program()
    {
        gymManagement = new GymManagement();
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("1. Cadastrar treinador");
        Console.WriteLine("2. Cadastrar cliente");
        Console.WriteLine("3. Treinadores com idade entre dois valores.");
        Console.WriteLine("4. Clientes com idade entre dois valores.");
        Console.WriteLine("5. Clientes com IMC maior que valor informado.");
        Console.WriteLine("6. Clientes em ordem alfabética.");
        Console.WriteLine("7. Clientes do mais velho para o mais novo.");
        Console.WriteLine("8. Treinadores e clientes aniversariantes do mês informado.");
        Console.WriteLine("0. Sair");        
    }

    private void Run()
    {
        string? choice;
        do 
        {
            DisplayMenu();

            Console.WriteLine("O que deseja fazer?");
            choice = Console.ReadLine();

            Console.WriteLine();

            switch(choice)
            {
                case "1":
                    gymManagement.CreateTrainer();
                    break;
                case "2":
                    gymManagement.CreateCustomer();
                    break;
                case "3":
                    gymManagement.PrintTrainersByAgeRange();
                    break;
                case "4":
                    gymManagement.PrintCustomersByAgeRange();
                    break;
                case "5":
                    gymManagement.PrintCustomersByIMC();
                    break;
                case "6":
                    gymManagement.PrintCustomersAlphabetically();
                    break;
                case "7":
                    gymManagement.PrintCustomersDescendingByAge();
                    break;
                case "8":
                    gymManagement.PrintBirthdays();
                    break;
            }
        } while (choice != "0");
    }

    public static void Main(string[] args)
    {
        Program gymProgram = new Program();
        gymProgram.Run();
    }
}