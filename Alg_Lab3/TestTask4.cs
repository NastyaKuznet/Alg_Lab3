using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class TestTask4
    {
        public void TestСountElementsContainInt()
        {
            Task4 task = new Task4();
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
            Task4 task = new Task4();
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
            object el = 3;
            Console.Write($"Функцию вставки списка самого в себя вслед за первым вхождением числа {el}:\n");
            task.InsertInYourselfAfterNumber(list, el);
            list.PrintList();
        }

        public void TestInsertItemIntoOrderedList()
        {
            Task4 task = new Task4();
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
            task.InsertItemIntoOrderedList(list, el);
            list.PrintList();
        }

        public void TestInsertYourselfEndEYourself()
        {
            Task4 task = new Task4();
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
            task.InsertYourselfEndEYourself(list);
            list.PrintList();
        }
    }
}
