using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public static class TextInterface
    {
        //static string[] textSetting = new string[] {"Минимальное значение элемента в массиве данных : ", "Максимальное значение элемента в массиве данных : ", "Максимальная длинна массива данных : ", "Шаг даных в итоговом отчете : " };
        //static Dictionary<string, string> heaps = new Dictionary<string, string>() { { "setting", "- Настройки работы алгоритмов -" }, { "algorithm", "- Алгоритмы -" }, { "path", "- Настройка пути сохранения результата -" } };
        static string listAlgorithms = "СТЕК:\n" +
                "1.1 Взять операции из файла\n" +
                "1.2 Ввести операции вручную\n" +
            "4 ЗАДАНИЕ:\n" +
            "4.1 Взять операции из файла\n" +
                "4.4 Ввести операции вручную\n" +
            "4.8 Взять операции из файла\n" +
            "4.9 Взять операции из файла\n";

        static string stackWithFile = "Введите путь к файлу: ";
        static string сommandsForStack = "\nКоманды для стека:\n" +
            "PUSH  -  1,[значение]\n" +
            "POP  -  2\n" +
            "TOP  -  3\n" +
            "ISEMPTY  -  4\n" +
            "PTINT  -  5\n" +
            "\nВведите команды через пробел: ";
        static string stackWithCommands = "Введите команды через пробел: ";
        //static string endListAlgo = "Выберите операцию. Для смены настроек алгоритма напишите \"настройки\"";
        static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";
        static string[] numbersAlgoritms = new string[] {"1.1", "1.2", "4.1", "4.4", "4.8", "4.9"};

        //public static string[] TextSetting { get { return textSetting; } }
        //public static Dictionary<string, string> Heaps { get { return heaps; } }
        public static string ListAlgorithms { get { return listAlgorithms; } }
        public static string StackWithFile { get { return stackWithFile; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string CommandsForStack { get { return сommandsForStack; } }
        public static string StackWithCommands { get { return stackWithCommands; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms;} }
    }
}
