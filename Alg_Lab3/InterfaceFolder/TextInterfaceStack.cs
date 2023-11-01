using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public static class TextInterfaceStack 
    {
        static string listStackStart = "СТЕК:\n" +
               "1. Взять операции из файла\n" +
               "2. Ввести операции вручную\n" +
                "3. Замер времени";
        static string stackWithFile = "Введите путь к файлу: ";
        static string сommandsForStack = "\nКоманды для стека:\n" +
            "1,[значение] - PUSH\n" +
            "2 - POP\n" +
            "3 - TOP\n" +
            "4 - ISEMPTY\n" +
            "5 -  PRINT\n" +
            "\nВведите команды через пробел: ";
        static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";

        static string[] numbersAlgoritms = new string[] { "0", "1", "2", "3" };
        public static string ListStackStart { get { return listStackStart; } }
        public static string StackWithFile { get { return stackWithFile; } }
        public static string CommandsForStack { get { return сommandsForStack; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms; } }
    }
}
