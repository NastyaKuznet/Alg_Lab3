﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class StackController
    {
        public MyStack _stack = new MyStack();
        public void StartWork(String path)
        {
            _stack.Clear();
            var file = new StreamReader(path);
            string? stringFromFile = file.ReadLine();
            string[] comands = stringFromFile.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateStack();
            ConsoleOutputStack cw = new ConsoleOutputStack();
            cw.StartPrintCommands(comands, _stack);
        }

        private void CreateStack()
        {
            for(int i = 0; i < 5; i++)
            {
                _stack.Push(i);
            }
        }
    }
}
