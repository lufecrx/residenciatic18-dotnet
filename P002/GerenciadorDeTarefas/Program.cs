using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

class Program
{
    private Manager taskManager;

    public Program()
    {
        var dirPath = "data/";
        var filePath = dirPath + "tasks.txt";

        // Verificar se o diretório não existe e criar
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);

        // Verificar se o arquivo existe e criar
        if (!File.Exists(filePath))
            using (File.Create(filePath)) { }

        taskManager = new Manager(filePath);
        taskManager.LoadFromFile();
    }

    private void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("========== MENU PRINCIPAL ==========");
        Console.WriteLine("1. Adicionar Tarefa");
        Console.WriteLine("2. Remover Tarefa");
        Console.WriteLine("3. Exibir Estatísticas");
        Console.WriteLine("4. Editar Tarefa");
        Console.WriteLine("5. Exibir Todas as Tarefas");
        Console.WriteLine("6. Exibir Todas as Tarefas Concluídas");
        Console.WriteLine("7. Exibir Todas as Tarefas Pendentes");
        Console.WriteLine("8. Marcar ou Desmarcar Tarefa");
        Console.WriteLine("0. Sair e Salvar Dados");
        Console.WriteLine("====================================");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Run()
    {
        taskManager.ShowAllTasks();
        int choice;
        do
        {
            DisplayMenu();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        // Adicionar Tarefa
                        Console.WriteLine("ADICIONAR TAREFA");
                        Task task = taskManager.CreateTask();
                        taskManager.AddTask(task);
                        break;

                    case 2:
                        // Remover Tarefa
                        Console.WriteLine("REMOVER TAREFA");
                        taskManager.ShowAllTasks();
                        taskManager.MenuRemoveTask();
                        break;

                    case 3:
                        // Exibir Estatísticas
                        Console.WriteLine("ESTATÍSTICAS");
                        taskManager.ShowStatistics();
                        break;

                    case 4:
                        // Editar Tarefa
                        Console.WriteLine("EDITAR TAREFA");
                        taskManager.EditTask();
                        break;

                    case 5:
                        // Exibir Todas as Tarefas
                        Console.WriteLine("TODAS AS TAREFAS");                
                        taskManager.ShowAllTasks();
                        break;
                    case 6:
                        // Exibir Todas as Tarefas Concluídas
                        taskManager.ShowConcludedTasks();
                        break;

                    case 7:
                        // Exibir Todas as Tarefas Pendentes
                        taskManager.ShowPendingTasks();
                        break;

                    case 8:
                        // Marcar ou Desmarcar Tarefa
                        Console.WriteLine("SELECIONE A TAREFA DESEJADA");
                        taskManager.ToggleTask();
                        break;

                    case 0:
                        // Sair
                        Console.WriteLine("Saindo do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
            Console.WriteLine();                        
            Console.WriteLine(); // Adicionar duas linhas em branco para melhor legibilidade
        } while (choice != 0);

        // Salvar as tarefas de volta no arquivo antes de sair
        taskManager.SaveToFile();
    }

    static void Main(string[] args)
    {
        Program taskManagerProgram = new Program();
        taskManagerProgram.Run();
    }
}

class Manager
{
    private List<Task> tasks;
    private string filePath;
    private int concluded;
    private int pending;

    public Manager(string filePath)
    {
        this.tasks = new List<Task>();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException($"Destino inválido para: {nameof(filePath)}");
        }
        this.filePath = filePath;
    }

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(this.filePath))
        {
            foreach (Task task in tasks)
            {
                writer.WriteLine($"{task.GetId()}|{task.GetTitle()}|{task.GetDescription()}|{task.IsConcluded()}|{task.GetTimeCreated()}|{task.GetDateLimit()}");
            }
        }
    }

    public void LoadFromFile()
    {
        tasks.Clear(); // Limpa as tarefas existentes antes de carregar do arquivo

        try
        {
            using (StreamReader reader = new StreamReader(this.filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('|');
                    int id = int.Parse(data[0]);
                    string title = data[1];
                    string description = data[2];
                    bool situation = bool.Parse(data[3]);
                    DateTime timeCreated = DateTime.Parse(data[4]);
                    DateTime dateLimit = DateTime.Parse(data[5]);

                    Task task = new Task(title, description, dateLimit);
                    // Definir os outros atributos
                    task.SetId(id);
                    task.ToggleSituation(situation);
                    task.SetTimeCreated(timeCreated);
                    // Adicionar tarefa a list
                    tasks.Add(task);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"O arquivo {filePath} não foi encontrado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar arquivo: {ex.Message}");
        }
    }

    public Task CreateTask()
    {
        string title, description;
        // Verifica se title e description não é nulo ou vazio
        while (true)
        {
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine();

            // Verificar se title não é nulo ou vazio
            if (!string.IsNullOrWhiteSpace(title))
            {
                Console.Write("Descrição da tarefa: ");
                description = Console.ReadLine();

                // Verificar se description não é nulo ou vazio
                if (!string.IsNullOrEmpty(description))
                {
                    // title e description não são vazios
                    break;
                }
                else
                {
                    Console.WriteLine("A descrição não pode ser nula ou vazia.");
                }
            }
            else
            {
                Console.WriteLine("O título não pode ser nulo ou vazio.");
            }
        }


        int day, month, year;
        DateTime dateLimit;
        while (true)
        {
            Console.Write("Ano para vencimento: ");
            if (int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Mês para vencimento (1 a 12): ");
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                {
                    Console.Write("Dia para vencimento: ");
                    if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
                    {
                        // Criar novo prazo de vencimento e colocar na tarefa
                        Console.WriteLine($"Data de vencimento: {day}/{month}/{year}");
                        dateLimit = new DateTime(year, month, day);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dia inválido ou fora do intervalo do mês.");
                    }
                }
                else
                {
                    Console.WriteLine("Mês inválido. Insira um valor entre 1 e 12.");
                }
            }
            else
            {
                Console.WriteLine("Ano inválido. Certifique-se de inserir um valor numérico para o ano.");
            }
        }

        Task newTask = new Task(title, description, dateLimit);

        return newTask;
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void MenuRemoveTask()
    {
        Console.WriteLine("Deseja remover pelo título ou pelo ID?");
        Console.WriteLine("1. Título");
        Console.WriteLine("2. ID");
        Console.WriteLine("0. Voltar");
        Console.Write("Escolha uma opção: ");
        int removeChoice;
        if (int.TryParse(Console.ReadLine(), out removeChoice))
        {
            switch (removeChoice)
            {
                case 1:
                    Console.Write("Título: ");
                    string title = Console.ReadLine();
                    RemoveTask(title);
                    break;
                case 2:
                    Console.Write("ID: ");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                        RemoveTask(id);
                    break;
                case 0:
                    return;
            }
        }
    }

    // Deletar task pelo título
    public void RemoveTask(string title)
    {
        tasks.RemoveAll(task => string.Equals(title, task.GetTitle(), StringComparison.OrdinalIgnoreCase));
    }

    // Deletar task pelo ID
    public void RemoveTask(int id) { tasks.RemoveAll(task => id == task.GetId()); }

    // Pesquisar task pelo título ou pela descrição
    public List<Task> SearchTask(string search)
    {
        List<Task> tasksSearched = new List<Task>();
        foreach (var task in tasks)
        {
            if (task.GetTitle().Contains(search) || task.GetDescription().Contains(search))
                tasksSearched.Add(task);
        }

        return tasksSearched;
    }

    // Pesquisar task específica pelo ID
    public Task SearchTaskID(int id)
    {
        foreach (var task in tasks)
        {
            if (id == task.GetId())
                return task;
        }

        return null;
    }


    public void GenerateStatistics(out Task oldestTask, out Task newestTask)
    {
        this.concluded = tasks.Count(task => task.IsConcluded());
        this.pending = tasks.Count(task => !task.IsConcluded());


        // Inicializar as datas e as tarefas com valores padrão para evitar erros
        DateTime date1 = DateTime.MinValue;
        DateTime date2 = DateTime.MinValue;
        oldestTask = tasks.FirstOrDefault();
        newestTask = tasks.FirstOrDefault();

        foreach (var task in tasks)
        {
            // Obter a data da tarefa atual
            date1 = task.GetTimeCreated();

            // Comparar a data da tarefa atual com a data da tarefa mais antiga
            int result = DateTime.Compare(date1, date2);

            // date1 é anterior a date2, atualizar a tarefa mais antiga
            if (result < 0)
                oldestTask = task;
            // date1 é posterior a date2, atualizar a tarefa mais recente
            else if (result > 0)
                newestTask = task;
            // se forem datas iguais, não acontece nada
        }
    }

    public void ShowStatistics()
    {
        Task oldestTask;
        Task newestTask;
        GenerateStatistics(out oldestTask, out newestTask);

        Console.WriteLine($"Nº de tarefas concluídas: {this.concluded}");
        Console.WriteLine($"Nº de tarefas pendentes: {this.pending}");
        Console.WriteLine($"Task mais antiga: {oldestTask.GetTitle()} | {oldestTask.GetTimeCreated()} - {oldestTask.GetDateLimit()}");
        Console.WriteLine($"Task mais recente: {newestTask.GetTitle()} | {newestTask.GetTimeCreated()} - {newestTask.GetDateLimit()}");
    }

    public void ShowConcludedTasks()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("TAREFAS CONCLUÍDAS");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (var task in tasks)
        {
            if (task.IsConcluded())
            {
                Console.WriteLine(task.ToString());
                Console.WriteLine();
            }
        }
    }

    public void ShowPendingTasks()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("TAREFAS PENDENTES");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (var task in tasks)
        {
            if (!task.IsConcluded())
            {
                Console.WriteLine(task.ToString());
                Console.WriteLine();
            }
        }
    }

    public void ShowAllTasks()
    {
        ShowConcludedTasks();
        ShowPendingTasks();
    }

    public void EditTask()
    {
        int id = 0;
        Task taskToEdit = GetTaskById(id);

        if (taskToEdit != null)
        {
            Console.WriteLine(taskToEdit.ToString());
            int field = GetFieldChoice();
            UpdateTaskField(taskToEdit, field);
        }
    }

    // Retornar uma tarefa específica pelo ID
    private Task GetTaskById(int id)
    {
        while (true)
        {
            Console.WriteLine("Digite o ID da tarefa (ou 0 para sair): ");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (id == 0)
                    return null;

                Task task = SearchTaskID(id);

                if (task == null)
                    Console.WriteLine($"A tarefa de ID {id} é inexistente.");
                else
                    return task;
            }
            else
            {
                Console.WriteLine("Por favor, insira um valor inteiro para o ID da tarefa.");
            }
        }
    }

    // Retornar a opção escolhida para alteração
    private int GetFieldChoice()
    {
        int field;
        while (true)
        {
            Console.WriteLine("Digite o número do campo para ser alterado:");
            Console.WriteLine("1 - Título.");
            Console.WriteLine("2 - Descrição.");
            Console.WriteLine("3 - Vencimento.");
            Console.WriteLine("0 - Voltar");

            if (int.TryParse(Console.ReadLine(), out field))
            {
                if (field >= 0 && field <= 3)
                    return field;
                else
                    Console.WriteLine("Por favor, insira um valor inteiro correspondente à opção desejada.");
            }
            else
            {
                Console.WriteLine("Por favor, insira um valor inteiro como opção.");
            }
        }
    }

    // Atualizar a tarefa e o campo escolhido
    private void UpdateTaskField(Task task, int field)
    {
        switch (field)
        {
            case 1:
                Console.Write("Novo título: ");
                string newTitle = Console.ReadLine();
                task.SetTitle(newTitle);
                break;
            case 2:
                Console.Write("Nova descrição: ");
                string newDescription = Console.ReadLine();
                task.SetDescription(newDescription);
                break;
            case 3:
                int day, month, year;

                Console.Write("Novo ano para vencimento: ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    Console.Write("Novo mês para vencimento (1 a 12): ");
                    if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                    {
                        Console.Write("Novo dia para vencimento: ");
                        if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Criar novo prazo de vencimento e colocar na tarefa
                            Console.WriteLine($"Nova data de vencimento: {day}/{month}/{year}");
                            DateTime newDate = new DateTime(year, month, day);
                            task.SetDateLimit(newDate);
                        }
                        else
                        {
                            Console.WriteLine("Dia inválido ou fora do intervalo do mês.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mês inválido. Insira um valor entre 1 e 12.");
                    }
                }
                else
                {
                    Console.WriteLine("Ano inválido. Certifique-se de inserir um valor numérico para o ano.");
                }
                break;
            case 0:
                return;
        }
    }

    // Marcar ou desmarcar task pelo ID
    public void ToggleTask()
    {
        int id = 0;
        Task taskToToggle = GetTaskById(id);

        if (taskToToggle != null)
        {
            taskToToggle.ToggleSituation();
        }
    }
}

class Task
{
    private static int nextId = 1; // Variável estática para armazenar o próximo id disponível

    private int id; // Atributo id para cada instância
    private string title;
    private string description;
    private bool situation; // True: concluída | False: pendente
    private DateTime timeCreated;
    private DateTime dateLimit;

    public Task(string title, string description, DateTime dateLimit)
    {
        this.id = nextId++;
        this.title = title;
        this.description = description;
        this.situation = false;
        this.dateLimit = dateLimit.Date;
        this.timeCreated = DateTime.Now;
    }

    public void ToggleSituation()
    {
        situation = !situation;
    }

    public void ToggleSituation(bool situation)
    {
        this.situation = situation;
    }


    public override string ToString()
    {
        return $"ID: {id} {Environment.NewLine}" +
               $"Título: {title} {Environment.NewLine}" +
               $"Descrição: {description} {Environment.NewLine}" +
               $"Situação: {(situation ? "concluída" : "pendente")} {Environment.NewLine}" +
               $"Data criada: {timeCreated.ToString()} {Environment.NewLine}" +
               $"Vencimento: {dateLimit.Date.ToString()}";
    }

    public int GetId() { return id; }
    public string GetTitle() { return title; }
    public string GetDescription() { return description; }
    public bool IsConcluded() { return situation; }
    public DateTime GetTimeCreated() { return timeCreated; }
    public DateTime GetDateLimit() { return dateLimit.Date; }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException($"Texto inválido para: {nameof(title)}");
        else
            this.title = title;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException($"Texto inválido para: {nameof(description)}");
        else
            this.description = description;
    }

    public void SetDateLimit(DateTime dateLimit)
    {
        this.dateLimit = dateLimit.Date;
    }

    public void SetId(int id)
    {
        this.id = id;
        if (id >= nextId)
        {
            nextId = id + 1;
        }
    }

    public void SetTimeCreated(DateTime timeCreated)
    {
        this.timeCreated = timeCreated;
    }

}
