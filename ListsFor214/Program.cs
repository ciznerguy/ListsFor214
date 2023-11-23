using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ListsFor214
{
    internal class Program
    {

        public static void printList(Node<int> head)
        {
            //  head >> 22  >> 3 >>4 >>null
            //  head  >> 3 >>4 >>null
            //   head >>4 >>null
            //  head>>null
            Node<int> headToKeep = head;
            while (head != null)
            {
                Console.Write($" {head.GetValue()}>>");
                head = head.GetNext();
            }
            Console.WriteLine("null");


        }

        public static int sumList(Node<int> head)
        {

            int sum = 0;

            //  head >> 22  >> 3 >>4 >>null  sum=0

            //  head  >> 3 >>4 >>null  sum=22

            //  head  >>4 >>null  sum=22+3 =25

            //  head   >>null  sum=22+3 =25+4 =29
            while (head != null)
            {
                sum = sum + head.GetValue();
                head = head.GetNext();
            }
            return sum;
        }

        public static Node<int> AddFirst(Node<int> list, int val)
        {
            /* Node<int> nodeToAdd = new Node<int>(val);
             nodeToAdd.SetNext(list);
             return nodeToAdd;
            
            Node<int> nodeToAdd = new Node<int>(val,list);
            return nodeToAdd;
            */

            return new Node<int>(val, list);
        }


        public static Node<int> AddLast(Node<int> list, int val)
        {
            Node<int> head = list;
            Node<int> nodeToAdd = new Node<int>(val);

            while (list.HasNext() == true)
            {
                list = list.GetNext();
            }

            list.SetNext(nodeToAdd);
            return head;

        }

        static Node<T> CreateLinkedList<T>(params T[] values)
        {
            Node<T> head = null;
            Node<T> current = null;

            for (int i = 0; i < values.Length; i++)
            {
                T value = values[i];

                if (head == null)
                {
                    head = new Node<T>(value);
                    current = head;
                }
                else
                {
                    Node<T> newNode = new Node<T>(value);
                    current.SetNext(newNode);
                    current = newNode;
                }
            }

            return head;
        }

        public static bool IsPrefix(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return true;
            }
            while (lst1 != null && lst2 != null)
            {
                if (lst1.GetValue() != lst2.GetValue())
                {
                    return false;
                }
                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();
            }

            if (lst1 != null && lst2 == null)
            {
                return false;
            }
            return true;
        }

        public static bool IsSubChain(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return true;
            }
            while (lst2 != null)
            {
                if (IsPrefix(lst1, lst2) == true)
                {
                    return true;
                }
                lst2 = lst2.GetNext();
            }
            return false;
        }

        public static Node<int> CopyList(Node<int> original)
        {
            Node<int> listToReturn = new Node<int>(-111);
            Node<int> current = listToReturn;
            while (original != null)
            {
                Node<int> nodeToAdd = new Node<int>(original.GetValue());
                current.SetNext(nodeToAdd);
                current = current.GetNext();
                original = original.GetNext();

            }
            return listToReturn.GetNext();

        }


        public static Node<int> OnlyEven(Node<int> original)
        {
            Node<int> listToReturn = new Node<int>(-111);
            Node<int> current = listToReturn;
            while (original != null)
            {
                if (original.GetValue() % 2 == 0)
                {
                    Node<int> nodeToAdd = new Node<int>(original.GetValue());
                    current.SetNext(nodeToAdd);
                    current = current.GetNext();

                }
                original = original.GetNext();
            }
            return listToReturn.GetNext();

        }


        public static Node<int> EvenThenOdd(Node<int> original)
        {
            Node<int> listToReturn = new Node<int>(-111);
            Node<int> current = listToReturn;
            Node<int> original2 = original;
            while (original != null)
            {
                if (original.GetValue() % 2 == 0)
                {
                    Node<int> nodeToAdd = new Node<int>(original.GetValue());
                    current.SetNext(nodeToAdd);
                    current = current.GetNext();

                }
                original = original.GetNext();
            }

            while (original2 != null)
            {
                if (original2.GetValue() % 2 != 0)
                {
                    Node<int> nodeToAdd = new Node<int>(original2.GetValue());
                    current.SetNext(nodeToAdd);
                    current = current.GetNext();

                }
                original2 = original2.GetNext();
            }


            return listToReturn.GetNext();

        }

        public static bool IsExist(Node<int> original, int num)
        {
            while (original != null)
            {
                if (original.GetValue() == num)
                {
                    return true;
                }
                original = original.GetNext();
            }
            return false;
        }

        public static Node<int> RemoveDuplicates(Node<int> original)
        {
            if(original == null)
            {
                return null;
            }
            Node<int> listToReturn = new Node<int>(original.GetValue());
            Node<int> current = listToReturn;
            while (original != null)
            {
                if(IsExist(listToReturn, original.GetValue()))
                {
                    original = original.GetNext();
                }
                else
                {
                    Node<int> nodeToAdd = new Node<int>(original.GetValue());
                    current.SetNext(nodeToAdd);
                    current = current.GetNext();
                    original = original.GetNext();
                }

            }
            return listToReturn;
        }


        public static Node<int> AddToSort(Node<int> original, int num)
        {
            Node<int> nodeToAdd = new Node<int>(num);
            if(original == null)
            {
                return nodeToAdd;
            }
            if(original.GetValue() > num)
            {
                nodeToAdd.SetNext(original);
                return nodeToAdd;
            }
            Node<int> current = original;
            while (current.GetNext() != null && num > current.GetNext().GetValue())
            {
                current = current.GetNext();
            }
            nodeToAdd.SetNext(current.GetNext());
            current.SetNext(nodeToAdd);
            return original;
        }

        public Node<int> BuildList(int number)
        {
            // בדיקה האם המספר נמצא בטווח המותר
            if (number < 1 || number > 20)
            {
                // המספר לא בטווח - ייחזר רשימה ריקה
                return null;
            }

            // בניית רשימה שכוללת חוליות מ-1 עד המספר
            Node<int> head = new Node<int>(1);
            Node<int> current = head;

            for (int i = 2; i <= number; i++)
            {
                Node<int> newNode = new Node<int>(i);
                current.SetNext(newNode);
                current = newNode;
            }

            return head;
        }


        static void Main(string[] args)
        {
            Node<int> lst1OnMain = CreateLinkedList(1, 2, 3,35);
            Node<int> sorted = AddToSort(lst1OnMain, -9);
            printList(sorted);
           

        }
    }
}
