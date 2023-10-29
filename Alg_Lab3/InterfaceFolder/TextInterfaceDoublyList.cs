﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public class TextInterfaceDoublyList
    {
        static string listDoublyLinkStart = "ДВУСВЯЗНЫЙ СПИСОК:\n" +
            "1. Функция переворачивания списка\n" +
            "2. Функция, которая переносит в начало (в конец), последний (первый) элемент\n" +
            "3. Функция, которая определяет количество различных элементов списка, содержащего целые числа\n" +
            "4. Функцию, которая удаляет из списка второй из двух одинаковых элементов\n" +
            "5. Функция вставки списка самого в себя вслед за первым вхождением числа х\n" +
            "6. Функция, которая вставляет в непустой список, элементы которого упорядочены " +
            "по не убыванию, новый элемент так, чтобы сохранилась упорядоченность\n" +
            "7. Функция, которая удаляет из списка L все элементы Е, если таковые имеются\n" +
            "8. Функцию, которая вставляет в список L новый элемент F перед первым вхождением элемента Е, если Е входит в L\n" +
            "9. Функция дописывает к списку новый список. Оба списка содержат целые числа. В основной программе считать их из файла\n" +
            "10. Функция, которая разбивает список целых чисел на два списка по первому вхождению заданного числа. " +
            "Если этого числа в списке нет, второй список будет пустым, а первый не изменится\n" +
            "11. Функция, которая удваивает список, т.е. приписывает в конец списка себя самого\n" +
            "12. Функция, которая меняет местами два элемента списка, заданные пользователем";


        static string listWithFile = "Введите путь к файлу: ";
        static string endListAlgo = "\nДля возвращения на главный экран нажмите \"0\"";

        static string[] numbersAlgoritms = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        public static string ListDoublyLinkStart { get { return listDoublyLinkStart; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms; } }
    }
}