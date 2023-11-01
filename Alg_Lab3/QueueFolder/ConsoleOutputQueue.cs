using System.Runtime.InteropServices.ComTypes;

namespace Alg_Lab3.QueueFolder;

public class ConsoleOutputQueue
{
    private static List<CommandsForQueue> dictionary = new List<CommandsForQueue>();
    private static MyQueue _newQueue = new MyQueue();
    private static string line;
    private static int _maxLen = 2;
    private static string emptyLine = new string(' ', 15);

    private static void GetDataList(string[] commands)
    {
        dictionary.Clear();
        foreach (var command in commands)
        {
            DataHandler(command);
        }
    }
    
    public static void StartPrintCommands(string[] commands, MyQueue myQueue)
    {
        _newQueue = myQueue;
        GetDataList(commands);
        PrintCommands();
    }

    private static void DataHandler(string command)
    {
        if (command.Contains(','))
        {
            string value = command.Split(',')[1];
            dictionary.Add(new CommandsForQueue(Commands.enqueue,value));
            _maxLen = Math.Max(value.Length, _maxLen);
            return;
        }

        switch (command)
        {
            case "2":
                dictionary.Add(new CommandsForQueue(Commands.dequeue));
                break;
            case "3":
                dictionary.Add(new CommandsForQueue(Commands.peek));
                break;
            case "4":
                dictionary.Add(new CommandsForQueue(Commands.isEmpty));
                break;
            case "5":
                dictionary.Add(new CommandsForQueue(Commands.print));
                break;
        }
    }

    private static void PrintCommands()
    {
        foreach (CommandsForQueue command in dictionary)
        {
            switch (command.Command)
            {
                case Commands.enqueue:
                    DoEnqueue(command.Value);
                    break;
                case Commands.dequeue:
                    DoDequeue();
                    break;
                case Commands.peek:
                    DoPeek();
                    break;
                case Commands.isEmpty:
                    DoIsEmpty();
                    break;
                case Commands.print:
                    DoPrint();
                    break;
            }
        }
    }

    private static void DoEnqueue(string value)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\nКоманда 1, {value} - ENQUEUE({value})" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Состояние очереди до и после:");
        PrintQueues(Commands.enqueue, value);
        _newQueue.Enqueue(value);
    }

    private static void DoDequeue()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\nКоманда 2 - DEQUEUE" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Состояние очереди до и после:");
        PrintQueues(Commands.dequeue);
        _newQueue.Dequeue();
    }

    private static void DoPeek()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nКоманда 3 - PEEK" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        string? value = _newQueue.Peek().ToString();
        Console.WriteLine("Состояние очереди: ");
        PrintPeek();
        Console.WriteLine($"Вывод при вызове команды Peek: {value}");
    }
    
    private static void DoIsEmpty()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nКоманда 4 - ISEMPTY" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Состояние очереди:");
        _newQueue.Print();
        Console.WriteLine($"Вывод при вывозе команды IsEmpty: {_newQueue.IsEmpty}\n");
    }

    private static void DoPrint()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nКоманда 5 - DOPRINT" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Состояние очереди: ");
        _newQueue.Print();
    }
    private static void PrintPeek()
    {
        for (int i = 0; i < _newQueue.Count(); i++)
        {
            if (i==0)
            {
                PrintCellForPeek(i);
            }
        } 
    }
    
    private static void PrintCellForPeek(int i)
    {
        Console.WriteLine($"+{line}+");
        string? value = Convert.ToString(_newQueue.ElementAt(i));
        string str = new string(' ', _maxLen - value.Length);
        Console.WriteLine($"| {str}{value} |" + "<-- Peek");
        Console.WriteLine($"+{line}+");
    }
    private static void PrintQueues(Commands command, string EnqueueValue = "")
    {
        MaxLen(_newQueue, EnqueueValue);
        line = new string('-', _maxLen + 2);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"+{line}+{emptyLine}+{line}+");
        for(int i = 0; i <= _newQueue.Count()-1; i++)
        {
            if (i == 0 && command == Commands.dequeue)
                PrintForDequeue(_newQueue.ElementAt(i));
            else if (i == _newQueue.Count() - 1 && command == Commands.enqueue)
            {
                PrintCell(i);
                PrintForEnqueue(EnqueueValue);
            }
            else
            {
                PrintCell(i);
            }
        }
        if(_newQueue.Count == 0 && command == Commands.enqueue)
        {
            PrintForEnqueue(EnqueueValue);
        }
        Console.WriteLine("\n");
    }

    private static void MaxLen(MyQueue myQueue, string? newValue = null)
    {
        _maxLen = 0;
        foreach (var obj in myQueue)
        {
            string? value = obj.ToString();
            _maxLen = Math.Max(value.Length, _maxLen);
        }
        if (newValue == null) return;
        _maxLen = Math.Max(newValue.Length, _maxLen);
    }

    private static void PrintForDequeue(object value)
    {
        string? value1 = Convert.ToString(value);
        string value2 = "";
        string str1 = new string(' ', _maxLen - value1.Length);
        string str2 = new string(' ', _maxLen - value2.Length);
        emptyLine = new string(' ', 15 - 6);
        Console.WriteLine($"| {str1}{value1} |" + $"<--Deq" + emptyLine + $"| {str2} |");
        emptyLine = new string(' ', 15);
        Console.WriteLine($"+{line}+" + emptyLine +$"+{line}+");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void PrintForEnqueue(object value)
    {
        string? value2 = Convert.ToString(value);
        string value1 = "";
        string str1 = new string(' ', _maxLen - value1.Length);
        string str2 = new string(' ', _maxLen - value2.Length);
        emptyLine = new string(' ', 15 - 6);
        Console.WriteLine($"| {str1}{value1} |" + $"<--Enq" + emptyLine + $"| {str2}{value2} |");
        emptyLine = new string(' ', 15);
        Console.WriteLine($"+{line}+" + emptyLine + $"+{line}+");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void PrintCell(int i)
    {
        string? value = Convert.ToString(_newQueue.ElementAt(i));
        string str = new string(' ', _maxLen - value.Length);
        Console.WriteLine($"| {str}{value} |" + emptyLine + $"| {str}{value} |");
        Console.WriteLine($"+{line}+" + emptyLine + $"+{line}+");
    }
}