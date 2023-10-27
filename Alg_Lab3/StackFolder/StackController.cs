using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class StackController
    {
        public void StartWorkWithFile(String path)
        {
            var file = new StreamReader(path);
            string? stringFromFile = file.ReadLine();
            string[] commands = stringFromFile.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ConsoleOutputStack.StartPrintCommands(commands);
        }

        //public void StartWorkWithList(List<string> listCommands)
        //{
        //    string[] comands = listCommands.ToArray();
        //    ConsoleOutputStack.StartPrintCommands(comands);
        //}

        public void StartWorkWithList(string[] commands)
        {
            ConsoleOutputStack.StartPrintCommands(commands);
        }
    }
}
