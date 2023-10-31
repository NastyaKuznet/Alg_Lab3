using Alg_Lab3.InterfaceFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg_Lab3.QueueFolder;

namespace Alg_Lab3
{
    public class CheckErrors
    {
        public static bool Check = true;
        private static MyStack _myStack = new MyStack();
        private static MyQueue _myQueue = new MyQueue();
        public static uint UintResult;

        public static void IsNumberAlgorithm(string? str, string[] commands)
        {
            Check = commands.Contains(str);
            if (!Check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестная команда.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void IsRightPath(string path)
        {
            try
            {
                File.WriteAllText(path + "\\text.txt", "lol");
                File.Delete(path + "\\text.txt");
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

        public static void IsRightPathForLists(string path)
        {
            try
            {
                foreach(string line in File.ReadLines(path))
                {
                    string[] str = line.Split(' ');
                }
            }
            catch
            {
                Check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестный путь.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void IsRightInt(string num)
        {
            Check = uint.TryParse(num, out UintResult);
            if (!Check || UintResult == 0)
            {
                Check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Число должно быть больше 0!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void IsRightPathForCommand(string path)
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
                Console.WriteLine("\nНеверно введены команды для стека, попробуйте еще раз.");
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
        
        public static void IsRightCommandsForQueue(string inputCommands)
        {
            try
            {
                QueueLoader queueLoader = new QueueLoader();
                string[] commands = inputCommands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                CheckCommandsForQueue(commands);
                Check = true;
            }
            catch
            {
                Check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНеверно введены команды для стека, попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void CheckCommandsForQueue(string[] commands)
        {
            foreach (string command in commands)
            {
                if (command.Contains(','))
                {
                    string value = command.Split(',')[1];
                    _myQueue.Enqueue(value);
                    continue;
                }

                switch (command)
                {
                    case "2":
                        _myQueue.Dequeue();
                        break;
                    case "3":
                        _myQueue.Peek();
                        break;
                    case "4":
                        bool flag = _myQueue.IsEmpty;
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
