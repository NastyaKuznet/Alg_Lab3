using Alg_Lab3.DoublyLinkedListFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public class InterfaceDoublyList
    {
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
    }
}
