namespace Alg_Lab3.QueueFolder;

public class QueueLoader
{
    public void LoadFromFile(String path)
    {
        var file = new StreamReader(path);
        string? line = file.ReadLine();
        string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        MyQueue myQueue = new MyQueue();
        ConsoleOutputQueue.StartPrintCommands(commands, myQueue);
    }

    public void LoadFromList(List<string> commands, MyQueue myQueue)
    {
        string[] comm = commands.ToArray(); 
        ConsoleOutputQueue.StartPrintCommands(comm,myQueue);
    }
}