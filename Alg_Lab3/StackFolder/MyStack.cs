using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Alg_Lab3.DoublyLinkedListFolder;

namespace Alg_Lab3
{
    public class MyStack : IEnumerable<object>, ICloneable
    {
        DoublyLinkedList<object> list = new DoublyLinkedList<object>();
        int count;
        private int _maxLen;

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
            count = 0;
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
            copy.list = (DoublyLinkedList<object>)list.Clone();
            return copy;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private void PrintStack()
        {
            FindMaxLen();
            string line = new string('-', _maxLen + 2);
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
                    WriteInStringBuilder(item, line, sb, "<--");
                    flag = false;
                }
                else
                    WriteInStringBuilder(item, line, sb);
            }
            sb.Append("\n");
            Console.WriteLine(sb.ToString());
        }

        private void WriteInStringBuilder(object item, string line, StringBuilder sb, string temp = null)
        {
            string value = Convert.ToString(item);
            string str = new string(' ', _maxLen - value.Length);
            sb.AppendLine($"| {str}{value} |{temp}");
            sb.AppendLine($"+{line}+");
        }

        private void FindMaxLen()
        {
            foreach (var item in list)
            {
                string value = item.ToString();
                _maxLen = Math.Max(value.Length, _maxLen);
            }
        }
    }

    
}
