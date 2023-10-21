using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class MyStack
    {
        DoublyLinkedList<object> list = new DoublyLinkedList<object>();
        int count;

        public int Count { get { return count; } }
        public bool isEmpty { get { return count == 0; } }

        public void Push(object data)
        {
            list.Add(data);
            count++;
        }

        public object Pop() 
        {
            var item = list.Tail.Data;
            list.Remove(item);
            count--;
            return item;
        }

        public object Top()
        {
            return list.Tail.Data;
        }

        public void Print()
        {
            foreach(var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void PrintRevers()
        {
            foreach (var item in list.BackEnumerator())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
