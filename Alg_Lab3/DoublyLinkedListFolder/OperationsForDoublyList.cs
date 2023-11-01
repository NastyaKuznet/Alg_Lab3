using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Alg_Lab3.DoublyLinkedListFolder
{
    public class OperationsForDoublyList 
    {
        public static void ReverseList(DoublyLinkedList<object> list)
        {
            if (list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<object> node1 = list.Head;
            DoublyNode<object> node2 = node1.Next;
            node1.Next = null;
            node1.Previous = node2;
            while (node2 != null)
            {
                node2.Previous = node2.Next;
                node2.Next = node1;
                node1 = node2;
                node2 = node2.Previous;
            }
            list.Head = node1;
        }

        public static void DeleteReplays(DoublyLinkedList<object> list)
        {
            if (list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            HashSet<object> hushSet = new HashSet<object>();

            DoublyNode<object> current = list.Head;

            while (current != null)
            {
                if (hushSet.Contains(current.Data))
                {
                    list.Remove(current.Data);
                    current = current.Next;
                }
                else
                {
                    hushSet.Add(current.Data);
                    current = current.Next;
                }
            }
        }

        public static void InsertElementBefore(object element, object newElement, DoublyLinkedList<object> list)
        {
            if (list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            if(list.Head.Equals(element))
            {
                list.AddFirst(newElement);
                return;
            }
            DoublyNode<object> current = list.Head;
            while (current != null)
            {
                if (current.Data == element)
                {
                    DoublyNode<object> node = new DoublyNode<object>(newElement);
                    DoublyNode<object> temp = current.Previous;
                    current.Previous.Next = node;
                    current.Previous = node;
                    node.Next = current;
                    node.Previous = temp;
                    return;
                }
                current = current.Next;
            }
        }

        public static void AddNewListToEnd(DoublyLinkedList<int> list1, DoublyLinkedList<int> list2)
        {
            DoublyNode<int> current = list2.Head;
            while (current != null)
            {
                list1.Add(current.Data);
                current = current.Next;
            }
        }

        List<object> unicList = new List<object>();
        public int СountUnicElementsContainInt(DoublyLinkedList<object> list)
        {
            int count = 0;
            bool isContainInt;
            int trash;
            StringBuilder storage = new StringBuilder();


            foreach (object item in list)
            {
                if (!CheckUnic(item)) continue;
                string strItem = item.ToString();
                if (string.IsNullOrEmpty(strItem)) continue;
                for (int i = 0; i < strItem.Length; i++)
                {
                    if (int.TryParse(strItem[i].ToString(), out trash) || strItem[i].Equals(',') || strItem[i].Equals('.'))
                    {
                        storage.Append(strItem[i]);
                    }
                    else
                    {
                        isContainInt = IsInt(storage);
                        if (isContainInt) break;
                        storage.Clear();
                    }
                }
                isContainInt = IsInt(storage);
                if (isContainInt) count++;
                isContainInt = false;
                storage.Clear();
            }
            return count;
        }

        private bool CheckUnic(object obj)
        {
            bool isUnic = !unicList.Contains(obj);
            if (isUnic)
                unicList.Add(obj);
            return isUnic;
        }

        private bool IsDouble(StringBuilder storage)
        {
            return storage.ToString().TrimEnd(',').Split(',').Length > 1 || storage.ToString().TrimEnd('.').Split('.').Length > 1;
        }

        private bool IsInt(StringBuilder storage)
        {
            return storage.Length != 0 && !IsDouble(storage);
        }

        public void InsertInYourselfAfterNumber(DoublyLinkedList<object> list, object x)
        {
            DoublyLinkedList<object> copyList = (DoublyLinkedList<object>)list.Clone();
            DoublyNode<object> current = list.Head;
            while (current != null)
            {
                if (current.Data.Equals(x))
                {
                    DoublyNode<object> next = current.Next;
                    current.Next = copyList.Head;
                    copyList.Head.Previous = current;
                    copyList.Tail.Next = next;
                    next.Previous = copyList.Tail;
                    break;
                }
                current = current.Next;
            }
        }

        public void InsertItemIntoOrderedList(DoublyLinkedList<int> list, int x)
        {
            DoublyNode<int> current = list.Head;
            while (current != null)
            {
                if (current.Data > x)
                {
                    DoublyNode<int> newItem = new DoublyNode<int>(x);
                    newItem.Previous = current.Previous;
                    current.Previous.Next = newItem;
                    current.Previous = newItem;
                    newItem.Next = current;
                    return;
                }
                current = current.Next;
            }
            list.Add(x);
        }

        public void InsertYourselfEndEYourself(DoublyLinkedList<object> list)
        {
            DoublyLinkedList<object> copyList = (DoublyLinkedList<object>)list.Clone();
            DoublyNode<object> current = copyList.Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
        }
    }
}
