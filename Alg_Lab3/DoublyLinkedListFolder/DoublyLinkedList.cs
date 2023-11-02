
﻿using System.Collections;


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
            if (left ==0)
            {
                Console.SetCursorPosition(left, top);
            }
            else
            {
                Console.SetCursorPosition(left - 2, top);
            }
            
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

        public void ReverseList()
        {
            if (head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<T> node1 = head;
            DoublyNode<T> node2 = node1.Next;
            node1.Next = null;
            node1.Previous = node2;
            while (node2 != null)
            {
                node2.Previous = node2.Next;
                node2.Next = node1;
                node1 = node2;
                node2 = node2.Previous;
            }
            head = node1;
        }

        public void DeleteDuplicates()
        {
            if (head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }

            DoublyLinkedList<T> list = new DoublyLinkedList<T>();   
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (list.Contains(current.Data))
                {
                    Remove(current.Data);
                    current = current.Next;
                }
                else
                {
                    list.Add(current.Data);
                    current = current.Next;
                }
            }
        }

        public void InsertElementBefore(T element, T newElement)
        {
            if (head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            if (head.Data.Equals(element))
            {
                AddFirst(newElement);
                return;
            }
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    DoublyNode<T> node = new DoublyNode<T>(newElement);
                    DoublyNode<T> temp = current.Previous;
                    current.Previous.Next = node;
                    current.Previous = node;
                    node.Next = current;
                    node.Previous = temp;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddNewListToEnd(DoublyLinkedList<T> list)
        {
            DoublyNode<T> current = list.Head;
            while (current != null)
            {
                Add(current.Data);
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
        
        public void MoveLastElementToHead(DoublyLinkedList<T> list)
        {
            var node = list.Head;
            while (node.Next != list.Tail)
            {
                node = node.Next;
            }

            node.Next = null;
            var temp = list.Tail;
            list.Tail = node;
            temp!.Next = list.Head;
            list.Head = temp;
        }

        public void MoveFirstElementToTail(DoublyLinkedList<T> list)
        {
            var temp = list.Head.Next;
            list.Head.Next = null;
            list.Tail.Next = list.Head;
            list.Head = temp;
            list.Tail = list.Tail.Next;
        }
        
        public T this[int index]
        {
            get
            {
                var result = Head;
                for (var i = 0; i < index; i++)
                {
                    result = result?.Next;
                }

                return result!.Data;
            }
            set
            {
                if (index == Count)
                {
                    Add(value);
                } else if (index == 0)
                {
                    Head = new DoublyNode<T>(value, Head?.Next);
                } 
                else
                {
                    var node = Head!;
                    for (var i = 0; i < index - 1; i++)
                    {
                        if (node.Next == null)
                        {
                            break;
                        }
                        node = node.Next;
                    }

                    var temp = node.Next!.Next;
                    node.Next = new DoublyNode<T>(value, temp);
                }
            }
        }
    }
}
