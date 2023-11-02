using System.ComponentModel.Design;
using System.Xml;
using Alg_Lab3.QueueFolder;

namespace Alg_Lab3.InterfaceFolder;

public class InterfaceQueue
{
    private int[] intValues = new int[] { ImportData.maxN, ImportData.step };
    private string[] stringValues = new string[] { ImportData.path };
    private MyQueue _myQueue = new MyQueue();

    public void Work()
    {
        _myQueue.Clear();
        WriteStartAlgorithm();
        NextCommand();
    }
    private void WriteStartAlgorithm()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(TextInterfaceQueue.ListQueueStart);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void NextCommand()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(TextInterface.EndListAlgo);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Введите команду для очереди: ");
        string? input = Console.ReadLine();
        CheckErrors.IsNumberAlgorithm(input, TextInterfaceQueue.NumbersAlgoritms);
        if (!CheckErrors.Check)
        {
            NextCommand();
        }

        switch (input)
        {
            case "1":
                CommandsFromFile();
                break;
            case "2":
                GetCommandFromConsole();
                break;
            case "3":
                GetTime();
                break;
            case "0":
                MainInterface.ReturnMainInterface();
                break;
        }
    }

    private void CommandsFromFile()
    {
        Console.WriteLine(TextInterfaceQueue.QueueWithFile);
        string? input = Console.ReadLine();
        if (input == "0")
        {
            MainInterface.ReturnMainInterface();
        }
        CheckErrors.IsRightPath(input);
        if (CheckErrors.Check)
        {
            QueueLoader queueLoader = new QueueLoader();
            queueLoader.LoadFromFile(input);
        }
        GetReturn();
    }

    private void GetReturn()
    {
        Console.WriteLine("Вернуться на главный экран - \"0\"\nПродолжить работу с очередью - \"1\"");
        string? input = Console.ReadLine();
        CheckErrors.IsNumberAlgorithm(input, new string[]{"0", "1"});
        if (!CheckErrors.Check)
        {
            GetReturn();
        }

        switch (input)
        {
            case "0":
                MainInterface interfac = new MainInterface();
                interfac.Work();
                break;
            case "1":
                Work();
                break;
        }
    }
    
    private void GetCommandFromConsole()
    {
        Console.WriteLine(TextInterfaceQueue.CommandsForQueue);
        string? input = Console.ReadLine();
        if (input == "0")
        {
            MainInterface.ReturnMainInterface();
        }
        CheckErrors.IsRightCommandsForQueue(input);
        if (CheckErrors.Check)
        {
            string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            QueueLoader queueLoader = new QueueLoader();
            queueLoader.LoadFromList(commands, _myQueue);
            GetTypeOfWork();
        }
        else
        {
            GetCommandFromConsole();
        }
    }
    private void GetTypeOfWork()
    {
        Console.WriteLine("\nВернуться на главный экран - \"0\"\nПродолжить работу с очередью - \"1\"" +
                          "\nПродолжить работу с получившейся очередью в этом режиме - \"2\""+
                          "\nПродолжить работу с новой очередью в этом режиме - \"3\"");
        string? input = Console.ReadLine();
        CheckErrors.IsNumberAlgorithm(input, new string[]{"0","1","2","3"});
        if (!CheckErrors.Check)
        {
            NextCommand();
        }
        switch (input)
        {
            case "0":
                MainInterface interfac = new MainInterface();
                interfac.Work();
                break;
            case "1":
                Work();
                break;
            case "2":
                GetCommandFromConsole();
                break;
            case "3":
                _myQueue.Clear();
                GetCommandFromConsole();
                break;
        }
    }

    private void GetTime()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
            $"\nПуть сохранения: {stringValues[0]}\n" +
            $"Максимальное количество команд: {intValues[0]}\n" +
            $"Шаг в итоговом отчете:  {intValues[1]}\n \n");
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine(
            "Вернуться на главный экран - \"0\"\n" +
            "Изменить путь - \"1\"\n" +
            "Изменить максимальное количество команд - \"2\"\n" +
            "Изменить шаг в итоговом отчете - \"3\"\n" +
            "Продолжить с текущими настройками - \"4\"") ;
        string? input = Console.ReadLine();
        CheckErrors.IsNumberAlgorithm(input, new string[]{"0", "1","2","3","4"});
        if (!CheckErrors.Check)
        {
            GetTime();
        }
        switch (input)
        {
            case "0":
                MainInterface interfac = new MainInterface();
                interfac.Work();
                break;
            case "1":
                ChangePath();
                break;
            case "2":
                ChangeMaxN();
                break;
            case "3":
                ChangeStep();
                break;
            case "4":
                StartGetTimeForQueue();
                break;
        }
        
    }
    
    private void ChangePath()
    {
        Console.Write("Введите новый путь: ");
        string? path = Console.ReadLine();
        CheckErrors.IsRightPath(path);
        if (!CheckErrors.Check)
        {
            GetTime();
        }
        else stringValues[0] = path;
        GetTime();
    }

    private void ChangeMaxN()
    {
        Console.Write("Введите максимальное количество команд: ");
        string? maxN = Console.ReadLine();
        CheckErrors.IsRightInt(maxN);
        if (!CheckErrors.Check)
        {
            GetTime();
        }
        else intValues[0] = int.Parse(maxN);
        GetTime();
    }

    private void ChangeStep()
    {
        Console.Write("Введите шаг: ");
        string? step = Console.ReadLine();
        CheckErrors.IsRightInt(step);
        if (!CheckErrors.Check)
        {
            GetTime();
        }
        else intValues[1] = int.Parse(step);
        GetTime();
    }
    private void StartGetTimeForQueue()
    {
        RewriteImportantData();
        TimerForQueue.WorkingQueue();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Результат смотрите по пути {stringValues[0]}");
        Console.ForegroundColor = ConsoleColor.White;
        GetTime();
    }
    private void RewriteImportantData()
    {
        ImportData.maxN = intValues[0];
        ImportData.step = intValues[1];
        ImportData.path = stringValues[0];
    }
    
}