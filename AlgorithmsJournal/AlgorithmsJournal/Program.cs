using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsJournal
{
    class Program
    {
        static void Main(string[] args)
        {

            var mainarray = new string[11]; 
            var auxarray = new string[11];
            var i = 0;

            for (int j = 0; j < 5; j++)
            {
                mainarray[j] = j.ToString();
            }
            for (int j = 5; j < 11; j++)
            {
                mainarray[j] = (i++).ToString();;
            }

            MergeSort.Merge2(mainarray, auxarray, 0, 4, 10);

        }




        public class ArrayStack
        {
            private string[] s;
            private int n = 0;
            public ArrayStack(int capacity)
            {
                s = new string[capacity];
            }

            public bool IsEmpty()
            {
                return n == 0;
            }

            public string pop()
            {
                return s[--n];
            }

            public void push(string s)
            {
               // s[n++] = s;
            }
        }
        private class LinkedStackOfListStrings
        {

            private Node first;
            private class Node
            {
                public string item;
                public Node next;
            }

            public bool isEmpty()
            {
                return first == null;
            }

            public void push(string item)
            {
                Node oldfirst = first;
                first = new Node();
                first.item = item;
                first.next = oldfirst;
            }

            public string pop()
            {
                string item = first.item;
                first = first.next;
                return item;
            }
        }
    }
}
