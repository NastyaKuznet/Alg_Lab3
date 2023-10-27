using Alg_Lab3.InterfaceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class CheckErrors
    {
        public static bool Check = true;
        private static MyStack _myStack = new MyStack();

        public static void IsNumberAlgorithm(string? str)
        {
            Check = TextInterface.NumbersAlgoritms.Contains(str);
            if (!Check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизветная команда.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void IsRightPath(string path)
        {
            try
            {
                var file = new StreamReader(path);
                string? stringFromFile = file.ReadLine();
                IsRightCommandsForStack(stringFromFile);
                Check = true;
            }
            catch
            {
                Check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестный путь.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void IsRightCommandsForStack(string inputCommands)
        {
            try
            {
                StackController stackController = new StackController();
                string[] commands = inputCommands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                CheckCommandsForStack(commands);
                Check = true;
            }
            catch
            {
                Check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНеверно введены команды для стека, попробуйте еще раз");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void CheckCommandsForStack(string[] commands)
        {
            foreach(string command in commands)
            {
                if (command.Contains(','))
                {
                    string value = command.Split(',')[1];
                    _myStack.Push(value);
                    continue;
                }
                switch (command)
                {
                    case "2":
                        _myStack.Pop();
                        break;
                    case "3":
                        _myStack.Top();
                        break;
                    case "4":
                        bool flag = _myStack.IsEmpty;
                        break;
                    case "5":
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}
