using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class ConsoleOutputStack
    {
        private static List<CommandsForStack> keyValuePairs = new List<CommandsForStack>();
        private static MyStack _newStack = new MyStack();
        private static int _maxLen = 2;
        private static string line;
        private static string emptyLine = new string(' ', 15);

        public static void StartPrintCommands(string[] commands, MyStack myStack)
        {
            _newStack = myStack;
            GetDataFromList(commands);
            PrintCommands();
        }

        private static void GetDataFromList(string[] commands)
        {
            keyValuePairs.Clear();
            foreach (string command in commands)
            {
                GetData(command);
            }
        }

        private static void GetData(string command)
        {
            if (command.Contains(','))
            {
                string value = command.Split(',')[1];
                keyValuePairs.Add(new CommandsForStack(Commands.PUSH, value));
                _maxLen = Math.Max(value.Length, _maxLen);
                return;
            }
            switch (command)
            {
                case "2":
                    keyValuePairs.Add(new CommandsForStack(Commands.POP));
                    break;
                case "3":
                    keyValuePairs.Add(new CommandsForStack(Commands.TOP));
                    break;
                case "4":
                    keyValuePairs.Add(new CommandsForStack(Commands.ISEMPTY));
                    break;
                case "5":
                    keyValuePairs.Add(new CommandsForStack(Commands.PRINT));
                    break;
            }
        }

        private static void PrintCommands()
        {
            foreach(CommandsForStack command in keyValuePairs)
            {
                switch (command.Command)
                {
                    case Commands.PUSH:
                        DoPush(command.Value);
                        break;
                    case Commands.POP:
                        DoPop();
                        break;
                    case Commands.TOP:
                        DoTop();
                        break;
                    case Commands.ISEMPTY:
                        DoIsEmpty();
                        break;
                    case Commands.PRINT:
                        DoPrint();
                        break;
                }
            }
        }

        private static void DoPush(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nКоманда 1,{value} - PUSH({value})" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Состояние стека до и после:");
            PrintStacks(Commands.PUSH, value);
            _newStack.Push(value);
        }

        private static void DoPop()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nКоманда 2 - POP" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Состояние стека до и после:");
            PrintStacks(Commands.POP);
            _newStack.Pop();
        }

        private static void DoTop()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nКоманда 3 - TOP" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            string value = _newStack.Top().ToString();
            Console.WriteLine("Состояние стека:");
            PrintStackWithGlow("<-- Top");
            Console.WriteLine($"Вывод при вывозе команды Top: {value}");
        }

        private static void DoIsEmpty()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nКоманда 4 - ISEMPTY" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Состояние стека:");
            _newStack.Print();
            Console.WriteLine($"Вывод при вывозе команды IsEmpty: {_newStack.IsEmpty}\n");
        }

        private static void DoPrint()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nКоманда 5 - PRINT" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Состояние стека:");
            _newStack.Print();
        }

        private static void PrintStackWithGlow(string message)
        {
            FindMaxLen(_newStack);
            line = new string('-', _maxLen + 2);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"+{line}+");
            bool flag = true;
            foreach (var item in _newStack.BackEnumerator())
            {
                if (flag)
                {
                    WriteInConsole(line, item, _maxLen, message);
                    flag = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    WriteInConsole(line, item, _maxLen);
                }
            }
            Console.WriteLine("\n");
        }

        private static void WriteInConsole(string line, object item, int maxLen, string message = "", int size = 0)
        {
            string value = Convert.ToString(item);
            string str = new string(' ', maxLen - value.Length);
            Console.WriteLine($"| {str}{value} |" + message);
            Console.WriteLine($"+{line}+");
        }


        private static void FindMaxLen(MyStack myStack, string newValue = null)
        {
            _maxLen = 0;
            foreach (var item in myStack)
            {
                string value = item.ToString();
                _maxLen = Math.Max(value.Length, _maxLen);
            }
            if (newValue != null)
            {
                _maxLen = Math.Max(newValue.Length, _maxLen);
            }
        }

        private static void PrintStacks(Commands command, string pushValue = "")
        {
            FindMaxLen(_newStack, pushValue);
            line = new string('-', _maxLen + 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"+{line}+{emptyLine}+{line}+");
            for(int i = _newStack.Count() - 1; i >= 0; i--)
            {
                if (i == _newStack.Count() - 1 && command == Commands.POP)
                    PrintForPop(_newStack.ElementAt(i));
                else if (i == _newStack.Count() - 1 && command == Commands.PUSH)
                {
                    PrintForPush(pushValue);
                    PrintCell(i);
                }
                else
                    PrintCell(i);        
            }
            if((_newStack.Count == 0 || _newStack == null) && command == Commands.PUSH)
                PrintForPush(pushValue);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintForPop(object value)
        {
            string value1 = Convert.ToString(value);
            string value2 = "";
            string str1 = new string(' ', _maxLen - value1.Length);
            string str2 = new string(' ', _maxLen - value2.Length);
            emptyLine = new string(' ', 15 - 6);
            Console.WriteLine($"| {str1}{value1} |" + $"<--Pop" + emptyLine + $"| {str2} |");
            emptyLine = new string(' ', 15);
            Console.WriteLine($"+{line}+" + emptyLine + $"+{line}+");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintForPush(object value)
        {
            string value2 = Convert.ToString(value);
            string value1 = "";
            string str1 = new string(' ', _maxLen - value1.Length);
            string str2 = new string(' ', _maxLen - value2.Length);
            Console.WriteLine($"| {str1} |"  + emptyLine + $"| {str2}{value2} |" + $"<--Push");
            Console.WriteLine($"+{line}+" + emptyLine + $"+{line}+");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintCell(int i)
        {
            string value = Convert.ToString(_newStack.ElementAt(i));
            string str = new string(' ', _maxLen - value.Length);
            Console.WriteLine($"| {str}{value} |" + emptyLine + $"| {str}{value} |");
            Console.WriteLine($"+{line}+" + emptyLine + $"+{line}+");
        }
    }
}
