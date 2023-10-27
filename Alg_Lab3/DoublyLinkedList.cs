using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class DoublyLinkedList<T> : IEnumerable<T>, ICloneable
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public DoublyNode<T> Head { get { return head; } }
        public DoublyNode<T> Tail { get { return tail; } }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if(head == null)
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

            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if(current != null)
            {
                if(current.Next != null)
                    current.Next.Previous = current.Previous;
                else 
                    tail = current.Previous;
                if(current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;
                count--;
                return true;
            }
            return false;
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
            while(current != null)
            {
                if(current.Data.Equals(data))
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
            while(current != null)
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

        public object Clone()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            DoublyNode<T> current = this.head;
            while(current != null)
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
    }
}
