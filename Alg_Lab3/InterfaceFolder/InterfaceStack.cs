using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg_Lab3.StackFolder;

namespace Alg_Lab3.InterfaceFolder
{
    public class InterfaceStack
    {
        int[] intValues = new int[] { ImportData.maxN, ImportData.step };
        string[] stringValues = new string[] { ImportData.path };
        private MyStack _myStack = new MyStack();

        public void Work()
        {
            _myStack.Clear();
            WriteStartAlgorithm();
            ChooseNext();
        }

        private void WriteStartAlgorithm()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterfaceStack.ListStackStart);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ChooseNext()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterface.EndListAlgo);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите команду для стека: ");
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, TextInterfaceStack.NumbersAlgoritms);
            if (!CheckErrors.Check) { ChooseNext(); }
            switch (answer)
            {
                case "1":
                    DoCommandFromFile();
                    break;
                case "2":
                    DoCommandHand();
                    break;
                case "3":
                    GetTime();
                    break;
                case "4":
                    TestPostfixCalculator text = new TestPostfixCalculator();
                    text.Start();
                    ChooseNext();
                    break;
                case "0":
                    MainInterface.ReturnMainInterface();
                    break;
            }
        }

        private void DoCommandFromFile()
        {
            Console.Write(TextInterfaceStack.StackWithFile);
            string? answer1 = Console.ReadLine();
            if (answer1 == "0")
            {
                MainInterface.ReturnMainInterface();
            }
            CheckErrors.IsRightPathForCommand(answer1);
            if (CheckErrors.Check)
            {
                StackController stackController = new StackController();
                stackController.StartWorkWithFile(answer1);
            }
            ChooseReturn();
        }

        private void ChooseReturn()
        {
            Console.WriteLine("Вернуться на главный экран - \"0\"\nПродолжить работу со стеком - \"1\"");
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, new string[] {"0", "1"});
            if (!CheckErrors.Check) { ChooseReturn(); }
            switch (answer)
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

        private void DoCommandHand()
        {
            Console.WriteLine(TextInterfaceStack.CommandsForStack);
            string? answer2 = Console.ReadLine();
            if (answer2 == "0") MainInterface.ReturnMainInterface();
            CheckErrors.IsRightCommandsForStack(answer2);
            if (CheckErrors.Check)
            {
                string[] commands = answer2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                StackController stackController = new StackController();
                stackController.StartWorkWithList(commands, _myStack);
                ChooseTypeOfWork();
            }
            else DoCommandHand();
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
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, new string[] { "0", "1", "2", "3", "4"});
            if (!CheckErrors.Check) { GetTime(); }
            switch (answer)
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
                    StartGetTimeForStack();
                    break;
            }
        }

        private void ChangePath()
        {
            Console.Write("Введите новый путь: ");
            string? path = Console.ReadLine();
            CheckErrors.IsRightPath(path);
            if (!CheckErrors.Check) { GetTime(); }
            else stringValues[0] = path;
            GetTime();
        }

        private void ChangeMaxN()
        {
            Console.Write("Введите максимальное количество команд: ");
            string? maxN = Console.ReadLine();
            CheckErrors.IsRightInt(maxN);
            if (!CheckErrors.Check) { GetTime(); }
            else intValues[0] = int.Parse(maxN);
            GetTime();
        }

        private void ChangeStep()
        {
            Console.Write("Введите шаг: ");
            string? step = Console.ReadLine();
            CheckErrors.IsRightInt(step);
            if (!CheckErrors.Check) { GetTime(); }
            else intValues[1] = int.Parse(step);
            GetTime();
        }

        private void StartGetTimeForStack()
        {
            RewriteImportantData();
            TimerStack.WorkingStack();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Результат смотрите по пути {stringValues[0]}");
            Console.ForegroundColor = ConsoleColor.White;
            GetTime();
        }

        private void ChooseTypeOfWork()
        {
            Console.WriteLine("\nВернуться на главный экран - \"0\"\nПродолжить работу со стеком - \"1\"" +
                "\nПродолжить работу с получившимся стеком в этом режиме - \"2\"" +
                "\nПродолжить работу с пустым стеком в этом режиме - \"3\"");
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, new string[] { "0", "1", "2", "3"});
            if (!CheckErrors.Check) { ChooseReturn(); }
            switch (answer)
            {
                case "0":
                    _myStack.Clear();
                    MainInterface interfac = new MainInterface();
                    interfac.Work();
                    break;
                case "1":
                    _myStack.Clear();
                    Work();
                    break;
                case "2":
                    DoCommandHand();
                    break;
                case "3":
                    _myStack.Clear();
                    DoCommandHand();
                    break;
            }
        }

        private void RewriteImportantData()
        {
            ImportData.maxN = intValues[0];
            ImportData.step = intValues[1];
            ImportData.path = stringValues[0];
        }
    }
}
