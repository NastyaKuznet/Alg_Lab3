using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public static class TextInterface
    {
        static string listAlgorithms = "Структура данных:\n" +
                "1. Работа со стеком\n" +
                "2. Работа с очередью\n" +
                "3. Работа со двусвязным списком\n";
      
        static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";
        static string[] numbersAlgoritms = new string[] { "1", "2", "3"};

        public static string ListAlgorithms { get { return listAlgorithms; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms; } }
    }
}
