using Alg_Lab3.InterfaceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class TestPostfixCalculator
    {
        public void Start()
        {
            Console.WriteLine("Напишите выражение, используя сепаратор между операциями и числами пробел.");
            string? input = Console.ReadLine();
            if (input.Equals("0")) MainInterface.ReturnMainInterface();
            try
            {
                PostfixCalculator calc = new PostfixCalculator(input);
                calc.Calculate(false); 
                Console.Write($"{calc.GetResult()}");
                Console.WriteLine(" <- Результат");
                Console.Write($"{calc.GetPostfixStr()}");
                Console.WriteLine(" <- Постфиксная запись\n");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Неверное выражение");
            }
        }
    }
}
