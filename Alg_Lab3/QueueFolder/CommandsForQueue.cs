namespace Alg_Lab3.QueueFolder;

public class CommandsForQueue
{
    public Commands Command { get; }
    public string Value { get; }

    public CommandsForQueue(Commands command, string value = null)
    {
        Command = command;
        Value = value;
    }
}