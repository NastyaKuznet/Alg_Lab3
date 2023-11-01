using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg_Lab3.DoublyLinkedListFolder;

namespace Alg_Lab3.QueueFolder
{
    public class MyQueue : IEnumerable<object>
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
            PrintQueue();
        }

        public object Peek()
        {
            return list.Head.Data;
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
        
        public IEnumerable<object> Enumerator()
        {
            DoublyNode<object> current = list.Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public void PrintQueue()
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
            for (int i = 0; i < list.Count; i++)
            {
                if (flag)
                {
                    PrintCellForPrint(sb, maxLen, i, line);
                    flag = false;
                }
                else
                {
                    PrintCellForPrints(sb, maxLen, i, line);
                }
            }
            sb.Append("\n");
            Console.WriteLine(sb.ToString());
        }

        private void PrintCellForPrint(StringBuilder sb, int maxLen, int i, string line)
        {
            string? value = Convert.ToString(list.ElementAt(i));
            string str = new string(' ', maxLen - value.Length);
            sb.AppendLine($"| {str}{value} |<--");
            sb.AppendLine($"+{line}+");
        }
        
        private void PrintCellForPrints(StringBuilder sb, int maxLen, int i, string line)
        {
            string? value = Convert.ToString(list.ElementAt(i));
            string str = new string(' ', maxLen - value.Length);
            sb.AppendLine($"| {str}{value} |");
            sb.AppendLine($"+{line}+");
        }
    }
}
