namespace Alg_Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            stack.Push(true);
            stack.Push(3);

            stack.Print();

            //TestDoublyLinkedList();
            //List<string> list = new List<string>();
            //list.Remove("a");

            StackController stackController = new StackController();
            //stackController.StartWorkWithFile("\"..\\\\..\\\\..\\\\..\\\\1.txt");
            List<string> list = new List<string>();
            list.Add("4");
            list.Add("1,cat");
            list.Add("2");
            list.Add("2");
            stackController.StartWorkWithList(list);
        }

        static void TestDoublyLinkedList()
        {
            DoublyLinkedList<int> ints= new DoublyLinkedList<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            Console.WriteLine("Проверка что были добавленны элементы в список и цикла");
            foreach(int i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();    
            Console.WriteLine("Проверка обратного цикла");
            foreach (int i in ints.BackEnumerator())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            ints.AddFirst(0);
            Console.WriteLine("Проверка добавления элемента в начало");
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            ints.Remove(2);
            Console.WriteLine("Проверка удаления элемента");
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Проверка существования элемента в списке");
            Console.WriteLine($"1 : {ints.Contains(1)}");
            Console.WriteLine($"2 : {ints.Contains(2)}");
            Console.WriteLine("Проверка очистки");
            ints.Clear();
            Console.WriteLine($"Теперь длина {ints.Count}");
        }
    }
}