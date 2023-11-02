using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    if (int.TryParse(strItem[i].ToString(), out trash) || strItem[i].Equals(',') ||
                        strItem[i].Equals('.'))
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
            return storage.ToString().TrimEnd(',').Split(',').Length > 1 ||
                   storage.ToString().TrimEnd('.').Split('.').Length > 1;
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

        public static void DeleteAllIfContains(DoublyLinkedList<object> list, object value)
        {
            DoublyNode<object> current = list.Head;
            var count = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    count++;
                }

                current = current.Next;
            }

            for (var i = 0; i < count; i++)
            {
                list.Remove(value);
            }
        }

        public static DoublyLinkedList<DoublyLinkedList<object>> SplitBy(DoublyLinkedList<object> list, object value)
        {
            var firstList = new DoublyLinkedList<object>();
            var secondList = new DoublyLinkedList<object>();
            var contains = false;
            foreach (var i in list)
            {
                if (i!.Equals(value))
                {
                    contains = true;
                    continue;
                }

                if (!contains)
                {
                    firstList.Add(i);
                }
                else
                {
                    secondList.Add(i);
                }
            }

            return new DoublyLinkedList<DoublyLinkedList<object>>
            {
                firstList,
                secondList
            };
        }

        public static void SwapTwoElements(DoublyLinkedList<object> list, object obj1, object obj2)
        {
            DoublyNode<object> element1 = null;
            DoublyNode<object> element2 = null;
            DoublyNode<object> current = list.Head;
            
            while (current != null)
            {
                if (Equals(obj1, current.Data))
                {
                    element1 = current;
                }
                else if (Equals(obj2, current.Data))
                {
                    element2 = current;
                }

                current = current.Next;
            }
            if (element1 == null || element2 == null)
            {
                return;
            }

            SwapNode(list, element1, element2);
        }

        private static void SwapNode(DoublyLinkedList<object> list, DoublyNode<object> node1, DoublyNode<object> node2)
        {
            if (node1.Next == node2 || node1.Previous == node2)
            {
                SwapAdjacentElements(list, node1, node2);
                return;
            }
            
            if (node1.Previous != null)
            {
                node1.Previous.Next = node2;
            }
            else
            {
                list.Head = node2;
            }

            if (node1.Next != null)
            {
                node1.Next.Previous = node2;
            }
            else
            {
                list.Tail = node2;
            }

            if (node2.Previous != null)
            {
                node2.Previous.Next = node1;
            }
            else
            {
                list.Head = node1;
            }

            if (node2.Next != null)
            {
                node2.Next.Previous = node1;
            }
            else
            {
                list.Tail = node1;
            }

            DoublyNode<object> temp = node1.Previous;
            node1.Previous = node2.Previous;
            node2.Previous = temp;

            temp = node1.Next;
            node1.Next = node2.Next;
            node2.Next = temp;
        }

        private static void SwapAdjacentElements(DoublyLinkedList<object> list, DoublyNode<object> nodeFirst, DoublyNode<object> nodeSecond)
        {
            DoublyNode<object> node1 = null;
            DoublyNode<object> node2 = null;
            if (nodeFirst.Next == nodeSecond)
            {
                node1 = nodeFirst;
                node2 = nodeSecond;
            }
            else
            {
                node1 = nodeSecond;
                node2 = nodeFirst;
            }

            if (node2.Next !=null)
            {
                node1.Next = node2.Next;
                node1.Next.Previous = node1;
            }
            else
            {
                node1.Next = null;
                list.Tail = node1;
            }

            if (node1.Previous != null)
            {
                node2.Previous = node1.Previous;
                node1.Previous.Next = node2;
            }
            else
            {
                node2.Previous = null;
                list.Head = node2;
            }

            node2.Next = node1;
            node1.Previous = node2;
        }
    }
}
