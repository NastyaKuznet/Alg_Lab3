using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.DoublyLinkedListFolder
{
    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }

        public DoublyNode(T data)
        {
            Data = data;
        }
        public DoublyNode(T value, DoublyNode<T>? next = null)
        {
            Data = value;
            Next = next;
        }
    }
}
