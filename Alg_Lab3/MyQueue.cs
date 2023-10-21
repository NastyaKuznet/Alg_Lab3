using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class MyQueue
    {
        DoublyLinkedList<object> list = new DoublyLinkedList<object>();
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Enqueue(object data)
        {
            list.Add(data);
            count++;
        }

        public object Dequeue()
        {
            var item = list.Head.Data;
            list.Remove(item);
            count--;
            return item;
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public object Peek()
        {
            return list.Head.Data;
        }
    }
}
