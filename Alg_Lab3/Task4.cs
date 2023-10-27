using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class Task4
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
            DoublyLinkedList<object> copyList = (DoublyLinkedList<object>) list.Clone();
            DoublyNode<object> current = list.Head;
            while(current != null)
            {
                if(current.Data.Equals(x))
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
            while(current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
        }
    }
}
