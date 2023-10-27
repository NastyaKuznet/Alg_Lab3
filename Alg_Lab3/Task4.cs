using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Alg_Lab3.DoublyLinkedListFolder;
using static System.Net.Mime.MediaTypeNames;

namespace Alg_Lab3
{
    public class Task4
    {
        public static void ReverseList(DoublyLinkedList<object> list)
        {
            if(list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<object> node1 = list.Head;
            DoublyNode<object> node2 = node1.Next;
            node1.Next = null;
            node1.Previous = node2;
            while(node2 != null)
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

        public static void Task8(object element, object newElemen, DoublyLinkedList<object> list)
        {
            if (list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<object> current = list.Head;
            while(current != null)
            {
                if (current.Data == element)
                {
                    DoublyNode<object> node = new DoublyNode<object>(newElemen);
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

        public static void Task9(DoublyLinkedList<int> list1, DoublyLinkedList<int> list2)
        {
            DoublyNode<int> current = list2.Head;
            while (current != null)
            {
                list1.Add(current.Data);
                current = current.Next;
            }
        }
    }
}
