using Lab_Alg_1;

namespace Alg_Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestPostfixCalculator testCalc = new TestPostfixCalculator();
            //testCalc.Start();
            //MyStack stack = new MyStack();
            //stack.Push(1);
            //stack.Push(true);
            //stack.Push(3);
            //stack.Print();

            Interface interfac = new Interface();
            interfac.Work();
            //DoublyLinkedList<object> doublyLinkedList = new DoublyLinkedList<object>();
            //doublyLinkedList.Add("1");
            //doublyLinkedList.Add("2");
            //doublyLinkedList.Add("3");
            //doublyLinkedList.Add("4");
            //doublyLinkedList.Add("4");
            ////doublyLinkedList.PrintList(doublyLinkedList.Head);
            //Task4 task4 = new Task4();
            //Task4.ReverseList(doublyLinkedList);
            //Task4.DeleteReplays(doublyLinkedList);
            //Console.WriteLine();
            //doublyLinkedList.PrintList(doublyLinkedList.Head);
            //Task4.Task8("2","f", doublyLinkedList);
            //Console.WriteLine();
            //doublyLinkedList.PrintList(doublyLinkedList.Head);


            //DoublyLinkedList<int> doublyLinkedListint1 = new DoublyLinkedList<int>();
            //DoublyLinkedList<int> doublyLinkedListint2 = new DoublyLinkedList<int>();
            ////doublyLinkedListint1.Add(1);
            ////doublyLinkedListint1.Add(2);
            ////doublyLinkedListint1.Add(3);
            ////doublyLinkedListint1.Add(4);
            //doublyLinkedListint2.Add(5);
            //doublyLinkedListint2.Add(6);
            //doublyLinkedListint2.Add(7);
            ////doublyLinkedListint1.PrintList(doublyLinkedListint1.Head);
            //Console.WriteLine();
            ////doublyLinkedListint2.PrintList(doublyLinkedListint2.Head);
            //Console.WriteLine();
            //Task4.Task9(doublyLinkedListint1, doublyLinkedListint2);
            //doublyLinkedListint1.PrintList(doublyLinkedListint1.Head);

            //TimerStack.WorkingStack();

            //StackController stackController = new StackController();
            //stackController.StartWorkWithFile("\"..\\\\..\\\\..\\\\..\\\\1.txt");
            //List<string> list = new List<string>();
            //list.Add("4");
            //list.Add("1,cat");
            //list.Add("2");
            //list.Add("2");
            //stackController.StartWorkWithList(list);
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