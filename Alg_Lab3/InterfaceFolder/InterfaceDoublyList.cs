using Alg_Lab3.DoublyLinkedListFolder;


namespace Alg_Lab3.InterfaceFolder
{
    public class InterfaceDoublyList
    {
        public void Work()
        {
            WriteStartAlgorithm();
            ChooseNext();
        }

        private void WriteStartAlgorithm()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterfaceDoublyList.ListDoublyLinkStart);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ChooseNext()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterfaceDoublyList.EndListAlgo);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите команду для списка: ");
            string? answer = Console.ReadLine();
            CheckErrors.IsNumberAlgorithm(answer, TextInterfaceDoublyList.NumbersAlgoritms);
            if (!CheckErrors.Check) { ChooseNext(); }
            switch (answer)
            {
                case "0":
                    MainInterface.ReturnMainInterface();
                    break;
                case "1":
                    TestReverseList();
                    ChooseNext();
                    break;
                case "2.1":
                    TestMoveLastElementToHead();
                    ChooseNext();
                    break;
                case "2.2":
                    TestMoveFirstElementToTail();
                    ChooseNext();
                    break;
                case "3":
                    TestСountElementsContainInt();
                    ChooseNext();
                    break;
                case "4":
                    TestDeleteReplays();
                    ChooseNext();
                    break;
                case "5":
                    TestInsertInYourselfAfterNumber();
                    ChooseNext();
                    break;
                case "6":
                    TestInsertItemIntoOrderedList();
                    ChooseNext();
                    break;
                case "7":
                    TestDeleteAllIfContains();
                    ChooseNext();
                    break;
                case "8":
                    TestInsertElementBefore();
                    ChooseNext();
                    break;
                case "9":
                    TestAddNewList();
                    ChooseNext();
                    break;
                case "10":
                    TestSplitBy();
                    ChooseNext();
                    break;
                case "11":
                    TestInsertYourselfEndEYourself();
                    ChooseNext();
                    break;
                case "12":
                    TestSwapTwoElements();
                    ChooseNext();
                    break;
            }
            ChooseNext();
        }

        public void TestReverseList()
        {
            DoublyLinkedList<object> doublyLinkedList = new DoublyLinkedList<object>();
            doublyLinkedList.Add("1");
            doublyLinkedList.Add("2");
            doublyLinkedList.Add("3");
            Console.Write("Список до: ");
            doublyLinkedList.PrintList();
            doublyLinkedList.ReverseList();
            Console.Write("\nСписок после: ");
            doublyLinkedList.PrintList();
        }

        public void TestDeleteReplays()
        {
            DoublyLinkedList<object> doublyLinkedList = new DoublyLinkedList<object>{ "1","1","2","2", "4","4"};
            Console.Write("\nСписок до: ");
            doublyLinkedList.PrintList();
            doublyLinkedList.DeleteDuplicates();
            Console.Write("\nСписок после: ");
            doublyLinkedList.PrintList();
        }

        public void TestInsertElementBefore()
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>() { "1", "2", "3", "2", "4", "4" };
            Console.WriteLine("\nВставить \"cat\" перед первым вхождением \"2\"");
            Console.Write("\nСписок до: ");
            doublyLinkedList.PrintList();
            doublyLinkedList.InsertElementBefore( "2", "cat");
            Console.Write("\nСписок после вставки \"сat\": ");
            doublyLinkedList.PrintList();
        }

        public void TestAddNewList()
        {
            Console.Write("Введите путь к файлу со списками: ");
            string? path = Console.ReadLine();
            CheckErrors.IsRightPathForLists(path);
            if (!CheckErrors.Check) 
            {
                if (path.Equals("0")) MainInterface.ReturnMainInterface();
                TestAddNewList();
            }
            List<string> strings = new List<string>();
            int i = 0;
            DoublyLinkedList<int> list1 = new DoublyLinkedList<int>();
            DoublyLinkedList<int> list2 = new DoublyLinkedList<int>();
            foreach (string line in File.ReadLines(path))
            {
                if (i == 0)
                    GetListFromStr(line, list1);
                if(i == 1)
                    GetListFromStr(line, list2);
                i++;
            }
            PrintAddNewList(list1, list2);

        }

        private void PrintAddNewList(DoublyLinkedList<int> list1, DoublyLinkedList<int> list2)
        {
            Console.Write("\nПервый список: ");
            list1.PrintList();
            Console.Write("Второй список: ");
            list2.PrintList();
            Console.Write("\nСписок после: ");
            list1.AddNewListToEnd(list2);
            list1.PrintList();

        }

        private void GetListFromStr(string line, DoublyLinkedList<int> list)
        {
            foreach (string str in line.Split(' '))
            {
                if (int.TryParse(str, out int num))
                    list.Add(num);
                else
                {
                    Console.WriteLine("Некорректные данные в файле");
                    TestAddNewList();
                }
            }
        }

        public void TestСountElementsContainInt()
        {
            OperationsForDoublyList task = new OperationsForDoublyList();
            DoublyLinkedList<object> list = new DoublyLinkedList<object>
            {
                1,
                "cat2",
                2.3,
                "c2,3at",
                "c2,3at4",
                "c4at2,3",
                "cat2,3asd 3",
                "c",
                "c3.a",
                "c3.",
                "c3."
            };
            list.PrintList();
            Console.Write("Количество уникальных элементов содержащих в себе целое число: ");
            Console.Write(task.СountUnicElementsContainInt(list));
        }

        public void TestInsertInYourselfAfterNumber()
        {
            OperationsForDoublyList task = new OperationsForDoublyList();
            DoublyLinkedList<object> list = new DoublyLinkedList<object>
            {
                1,
                2,
                3,
                10,
                4,
                9,
                5,
            };
            list.PrintList();
            object el = 5;
            Console.Write($"Функцию вставки списка самого в себя вслед за первым вхождением числа {el}:\n");
            list.InsertInYourselfAfterNumber( el);
            list.PrintList();
        }

        public void TestInsertItemIntoOrderedList()
        {
            OperationsForDoublyList task = new OperationsForDoublyList();
            DoublyLinkedList<int> list = new DoublyLinkedList<int>
            {
                1,
                2,
                3,
                5,
                7,
                9,
            };
            list.PrintList();
            int el = 3;
            Console.Write($"Функцию вставки элемента {el} в упорядоченный список:\n");
            list.InsertItemIntoOrderedListInt(el);
            list.PrintList();
        }

        public void TestInsertYourselfEndEYourself()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>
            {
                1,
                "cat2",
                2.3,
                "c2,3at",
                "c2,3at4",
                "c4at2,3",
                "cat2,3asd 3",
                "c",
                "c3.a",
                "c3."
            };
            list.PrintList();
            Console.WriteLine("Функция приписывает самого себя в конец списка: ");
            list.InsertYourselfEndEYourself();
            list.PrintList();
        }

        public void TestMoveLastElementToHead()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            Console.WriteLine("Список до: ");
            list.PrintList();
            list.MoveLastElementToHead(list);
            Console.WriteLine("Список после: ");
            list.PrintList();
            ChooseNext();
        }

        public void TestMoveFirstElementToTail()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            Console.WriteLine("Список до: ");
            list.PrintList();
            list.MoveFirstElementToTail(list);
            Console.WriteLine("Список после: ");
            list.PrintList();
        }

        public void TestDeleteAllIfContains()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.Add("132");
            list.Add("cat");
            list.Add("88");
            list.Add("4");
            list.Add("cat");
            list.Add(10);
            Console.WriteLine("Список до: ");
            list.PrintList();
            object element = "cat";
            Console.WriteLine($"Функция удаляет из списка все вхождения элемента \"{element}\"");
            OperationsForDoublyList.DeleteAllIfContains(list, element);
            Console.WriteLine("Список после: ");
            list.PrintList();
        }

        public void TestSplitBy()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.Add(2);
            list.Add(123);
            list.Add(4);
            list.Add(12);
            list.Add(0);
            list.Add(1);
            int element = 4;
            Console.WriteLine("Список до: ");
            list.PrintList();
            Console.WriteLine($"\nРазделение списка по элементу: {element}");
            var temp = OperationsForDoublyList.SplitBy(list,element);
            Console.WriteLine("Первый получившийся список: ");
            temp[0].PrintList();
            Console.WriteLine("Второй получившийся список: ");
            temp[1].PrintList();
        }

        public void TestSwapTwoElements()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.Add("32");
            list.Add("cat");
            list.Add("148");
            list.Add("alg");
            list.Add("1.1");
            list.Add("go");
            list.Add("5");
            object element1 = 2;
            object element2 = 4;
            Console.WriteLine("Список до: ");
            list.PrintList();
            Console.Write("Введите элемент 1:  ");
            object input1 = Console.ReadLine();
            Console.Write("Введите элемент 2:  ");
            object input2 = Console.ReadLine();
            Console.WriteLine($"Функция меняет местами объекты: {input1}, {input2}");
            OperationsForDoublyList.SwapTwoElements(list, input1, input2);
            Console.WriteLine("Список после: ");
            list.PrintList();
        }
    }
}
