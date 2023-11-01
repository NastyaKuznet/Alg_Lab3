﻿using Alg_Lab3.DoublyLinkedListFolder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                case "2":
                    ChooseNext();
                    break;
                case "3":
                    ChooseNext();
                    break;
                case "4":
                    TestDeleteReplays();
                    ChooseNext();
                    break;
                case "5":
                    ChooseNext();
                    break;
                case "6":
                    ChooseNext();
                    break;
                case "7":
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
                    ChooseNext();
                    break;
                case "11":
                    ChooseNext();
                    break;
                case "12":
                    ChooseNext();
                    break;
            }
        }

        public void TestReverseList()
        {
            DoublyLinkedList<object> doublyLinkedList = new DoublyLinkedList<object>();
            doublyLinkedList.Add("1");
            doublyLinkedList.Add("2");
            doublyLinkedList.Add("3");
            Console.Write("Список до: ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
            doublyLinkedList.ReverseList();
            Console.Write("\nСписок после: ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
        }

        public void TestDeleteReplays()
        {
            DoublyLinkedList<object> doublyLinkedList = new DoublyLinkedList<object>{ "1","1","2","2", "4","4"};
            Console.Write("\nСписок до: ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
            doublyLinkedList.DeleteDuplicates();
            Console.Write("\nСписок после: ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
        }

        public void TestInsertElementBefore()
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>() { "1", "2", "3", "2", "4", "4" };
            Console.WriteLine("\nВставить \"cat\" перед первым вхождением \"2\"");
            Console.Write("\nСписок до: ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
            doublyLinkedList.InsertElementBefore( "2", "cat");
            Console.Write("\nСписок после вставки \"сat\": ");
            doublyLinkedList.PrintList(doublyLinkedList.Head);
        }

        public void TestAddNewList()
        {
            Console.Write("Введите путь к файлу со списками: ");
            string? path = Console.ReadLine();
            CheckErrors.IsRightPathForLists(path);
            if (!CheckErrors.Check) { TestAddNewList(); }
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

        private void PrintAddNewList(DoublyLinkedList<int> list1, DoublyLinkedList<int> list2)
        {
            Console.Write("\nПервый список: ");
            list1.PrintList(list1.Head);
            Console.Write("Второй список: ");
            list2.PrintList(list2.Head);
            Console.Write("\nСписок после: ");
            list1.AddNewListToEnd(list2);
            list1.PrintList(list1.Head);
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
            object el = 3;
            Console.Write($"Функцию вставки списка самого в себя вслед за первым вхождением числа {el}:\n");
            task.InsertInYourselfAfterNumber(list, el);
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
            task.InsertItemIntoOrderedList(list, el);
            list.PrintList();
        }

        public void TestInsertYourselfEndEYourself()
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
                "c3."
            };
            list.PrintList();
            Console.WriteLine("Функция приписывает самого себя в конец списка: ");
            task.InsertYourselfEndEYourself(list);
            list.PrintList();
        }
    }
}
