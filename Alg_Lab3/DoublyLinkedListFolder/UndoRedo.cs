using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.DoublyLinkedListFolder
{
    public class UndoRedo
    {
        private DoublyNode<string> Current;
        private DoublyLinkedList<string> NamePages = new DoublyLinkedList<string>();

        public UndoRedo(DoublyLinkedList<string> namePages, string namePage)
        {
            NamePages = namePages;
            DoublyNode<string> current = NamePages.Head;
            while(current != null)
            {
                if(current.Data.Equals(namePage))
                {
                    Current = current;
                }
            }
        }


        public string ChosePage(string action)
        {
            if(action.Equals("undo"))
            {
                return Current.Previous.Data;
            }
            else if(action.Equals("redo"))
            {
                return Current.Next.Data;
            }
            return "none";
        }
    }
}
