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
               "1 Взять операции из файла\n" +
               "2 Ввести операции вручную\n";
        static string stackWithFile = "Введите путь к файлу: ";
        static string сommandsForStack = "\nКоманды для стека:\n" +
            "PUSH  -  1,[значение]\n" +
            "POP  -  2\n" +
            "TOP  -  3\n" +
            "ISEMPTY  -  4\n" +
            "PTINT  -  5\n" +
            "\nВведите команды через пробел: ";
        static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";

        static string[] numbersAlgoritms = new string[] { "0", "1", "2" };
        public static string ListStackStart { get { return listStackStart; } }
        public static string StackWithFile { get { return stackWithFile; } }
        public static string CommandsForStack { get { return сommandsForStack; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms; } }
    }
}
