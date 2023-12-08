class Program
{
    private StockManager stockManager;

    public Program()
    {
        var dirPath = "data/";
        var filePath = dirPath + "stock.txt";

        // Verificar se o diretório não existe e criar
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);

        // Verificar se o arquivo existe e criar
        if (!File.Exists(filePath))
            using (File.Create(filePath)) { }

        stockManager = new StockManager(filePath);
        stockManager.LoadFromFile();
    }
    
    private void DisplayMenu(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine("===== Stock Management System =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Delete Product");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. List Products");
            Console.WriteLine("5. Limit Stock Report");
            Console.WriteLine("6. Price Stock Report");
            Console.WriteLine("7. Stock Value Report");
            Console.WriteLine("0. Exit and Save");
        Console.WriteLine("===================================");
        Console.ResetColor();
    }

    private void Run() 
    {
        string? choice;
        do
        {
            DisplayMenu(ConsoleColor.Cyan);
            
            Console.Write("Enter your choice (0-9): ");
            choice = Console.ReadLine();
            
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Add Product");
                    stockManager.CreateProduct();
                    break;
                case "2":
                    Console.WriteLine("Delete Product");
                    stockManager.DeleteProduct();
                    break;
                case "3":
                    Console.WriteLine("Update Stock");
                    stockManager.UpdateStock();
                    break;
                case "4":
                    Console.WriteLine("List Products");
                    stockManager.ListProducts();
                    break;
                case "5":
                    Console.WriteLine("Limit Stock Report");
                    stockManager.LimitStockReport();
                    break;
                case "6":
                    Console.WriteLine("Price Stock Report");
                    stockManager.PriceStockReport();
                    break;
                case "7":
                    Console.WriteLine("Stock Value Report");
                    stockManager.StockValueReport();
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    break;
            }
        } while (choice != "0");

        // Salvar estoque antes de fechar o programa
        stockManager.SaveToFile();
    }

    static void Main(string[] args)
    {
        Program stockProductProgram = new Program();
        stockProductProgram.Run();
    }
}