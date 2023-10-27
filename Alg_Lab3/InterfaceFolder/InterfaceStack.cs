using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public class InterfaceStack
    {
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
                case "0":
                    MainInterface.ReturnMainInterface();
                    break;
            }
        }

        private void DoCommandFromFile()
        {
            Console.WriteLine(TextInterfaceStack.StackWithFile);
            string? answer1 = Console.ReadLine();
            if (answer1 == "0")
            {
                MainInterface.ReturnMainInterface();
            }
            CheckErrors.IsRightPath(answer1);
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

        private void ChooseTypeOfWork()
        {
            Console.WriteLine("Вернуться на главный экран - \"0\"\nПродолжить работу со стеком - \"1\"" +
                "\nПродолжить работу с получившимся стеком в этом режиме - \"2\"" +
                "\nПродолжить работу с пустым стеком в этом режиме - \"3\"");
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, new string[] { "0", "1", "2", "3"});
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
                case "2":
                    DoCommandHand();
                    break;
                case "3":
                    _myStack.Clear();
                    DoCommandHand();
                    break;
            }
        }

    }
}
