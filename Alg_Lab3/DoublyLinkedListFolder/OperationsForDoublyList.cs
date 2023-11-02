
﻿using System.Text;



namespace Alg_Lab3.DoublyLinkedListFolder
{
    public class OperationsForDoublyList
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
                    if (int.TryParse(strItem[i].ToString(), out trash) || strItem[i].Equals(',') ||
                        strItem[i].Equals('.'))
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
            return storage.ToString().TrimEnd(',').Split(',').Length > 1 ||
                   storage.ToString().TrimEnd('.').Split('.').Length > 1;
        }

        private bool IsInt(StringBuilder storage)
        {
            return storage.Length != 0 && !IsDouble(storage);
        }
    }
}
