using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class MyStack : IEnumerable<object>, ICloneable
    {
        DoublyLinkedList<object> list = new DoublyLinkedList<object>();
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

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
            PrintStack();
        }

        public void PrintRevers()
        {
            foreach (var item in list.BackEnumerator())
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Clear() {
            list.Clear();
        }

        public IEnumerator<object> GetEnumerator()
        {
            DoublyNode<object> current = list.Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerable<object> BackEnumerator()
        {
            DoublyNode<object> current = list.Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public MyStack Clone()
        {
            MyStack copy = (MyStack)this.MemberwiseClone();
            copy.list = this.list;
            return copy;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private void PrintStack()
        {
            int maxLen = 0;
            foreach (var item in list)
            {
                string value = item.ToString();
                maxLen = Math.Max(value.Length, maxLen);
            }

            string line = new string('-', maxLen + 2);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"+{line}+");
            if(list.Count == 0)
            {
                sb.AppendLine($"|  |");
                sb.AppendLine($"+{line}+");
                Console.WriteLine(sb.ToString());
                return;
            }
            bool flag = true;
            foreach(var item in list.BackEnumerator())
            {
                if (flag)
                {
                    string value = Convert.ToString(item);
                    string str = new string(' ', maxLen - value.Length);
                    sb.AppendLine($"| {str}{value} |<--");
                    sb.AppendLine($"+{line}+");
                    flag = false;
                }
                else
                {
                    string value = Convert.ToString(item);
                    string str = new string(' ', maxLen - value.Length);
                    sb.AppendLine($"| {str}{value} |");
                    sb.AppendLine($"+{line}+");
                }
               
            }
            sb.Append("\n");
            Console.WriteLine(sb.ToString());
        }
    }
}
