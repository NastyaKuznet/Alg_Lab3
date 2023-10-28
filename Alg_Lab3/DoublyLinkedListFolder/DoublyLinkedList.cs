using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alg_Lab3.DoublyLinkedListFolder
{
    public class DoublyLinkedList<T> : IEnumerable<T>, ICloneable
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public DoublyNode<T> Head { get { return head; } set { head = value; } }
        public DoublyNode<T> Tail { get { return tail; } set { tail = value; } }

        public void PrintList(DoublyNode<T> head)
        {
            if (head == null)
                Console.Write("Doubly Linked list empty");

            while (head != null)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
            Console.WriteLine();
        }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = node;
            }
            count++;
        }

        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;
                count--;
                return true;
            }
            return false;
        }

        public object Clone()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            DoublyNode<T> current = this.head;
            while (current != null)
            {
                DoublyNode<T> newItem = new DoublyNode<T>(current.Data);
                newList.Add(newItem.Data);
                current = current.Next;
            }
            return newList;
        }
        public void PrintList()
        {
            foreach (T item in this)
            {
                Console.Write($"{item.ToString()} - ");
            }
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(left - 2, top);
            Console.WriteLine(" ");
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

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

        public static void Task8(object element, object newElemen, DoublyLinkedList<object> list)
        {
            if (list.Head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<object> current = list.Head;
            while (current != null)
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

        public void InsertInYourselfAfterNumber(object x)
        {
            DoublyLinkedList<T> copyList = (DoublyLinkedList<T>)this.Clone();
            DoublyNode<T> current = this.Head;
            while (current.Next != null)
            {
                if (current.Data.Equals(x))
                {
                    DoublyNode<T> next = current.Next;
                    current.Next = copyList.Head;
                    copyList.Head.Previous = current;
                    copyList.Tail.Next = next;
                    next.Previous = copyList.Tail;
                    break;
                }
                current = current.Next;
            }
            if (this.Tail.Data.Equals(x))
            {
                Tail.Next = copyList.Head;
                copyList.Head.Previous = Tail;
                Tail = copyList.Tail;
            }
        }

        public void InsertItemIntoOrderedListInt(T x)
        {
            if (this != null && int.TryParse(this.head.Data.ToString(), out int num) && int.TryParse(x.ToString(), out int num1) && IsOrderedListForInt())
            {
                DoublyNode<T> current = this.Head;
                while (current != null)
                {
                    if (int.Parse(current.Data.ToString()) > int.Parse(x.ToString()))
                    {
                        DoublyNode<T> newItem = new DoublyNode<T>(x);
                        newItem.Previous = current.Previous;
                        current.Previous.Next = newItem;
                        current.Previous = newItem;
                        newItem.Next = current;
                        return;
                    }
                    current = current.Next;
                }
                DoublyNode<T> newItem2 = new DoublyNode<T>(x);
                this.Tail.Next = newItem2;
                newItem2.Previous = this.Tail;
                Tail = newItem2;
            }
        }

        public bool IsOrderedListForInt()
        {
            if (this == null || !int.TryParse(this.head.Data.ToString(), out int num)) return false;
            DoublyNode<T> current = this.Head;
            while(current.Next != null)
            {
                if(int.Parse(current.Data.ToString()) > int.Parse(current.Next.Data.ToString()))
                    return false;
                current = current.Next;
            }
            return true;
        }

        public void InsertYourselfEndEYourself()
        {
            DoublyLinkedList<T> copyList = (DoublyLinkedList<T>)this.Clone();
            this.tail.Next = copyList.Head;
            copyList.Head.Previous = copyList.Tail;
            tail = copyList.Tail;
        }
    }
}
