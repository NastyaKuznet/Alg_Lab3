namespace Alg_Lab3.InterfaceFolder;
public static class TextInterfaceQueue
{
    static string listQueueStart = "ОЧЕРЕДЬ:\n" +
                                   "1. Взять операции из файла\n" +
                                   "2. Ввести операции вручную\n" +
                                   "3. Замер времени";
    static string queueWithFile = "Введите путь к файлу: ";
    static string сommandsForQueue = "\nКоманды для очереди:\n" +
                                     "1,[значение] - Добавление элемента (ENQUEUE)\n" +
                                     "2 - Удаление (DEQUEUE)\n" +
                                     "3 - Просмотр начала очереди(PEEK)\n" +
                                     "4 - Проверка на пустоту - (ISEMPTY)\n" +
                                     "5 - Печать - (PTINT)\n" +
                                     "\nВведите команды через пробел: ";
    static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";

    static string[] numbersAlgoritms = new string[] { "0", "1", "2", "3" };
    public static string ListQueueStart { get { return listQueueStart; } }
    public static string QueueWithFile { get { return queueWithFile; } }
    public static string CommandsForQueue { get { return сommandsForQueue; } }
    public static string EndListAlgo { get { return endListAlgo; } }
    public static string[] NumbersAlgoritms { get { return numbersAlgoritms; } }
}