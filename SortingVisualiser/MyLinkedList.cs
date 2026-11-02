using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser
{
    public class MyLinkedList
    {
        int size = 0;
        Node head;

        public void ConvertArrayToLinkedList(int[] array)
        {
            if (array.Length == 0)
            {
                head = null;
                size = 0;
                return;
            }
            head = new Node(array[0]);
            Node current = head;
            for (int i = 1; i < array.Length; i++)
            {
                current.Next = new Node(array[i]);
                current = current.Next;
            }
            size = array.Length;
        }

        public int[] ConvertLinkedListToArray()
        {
            int[] array = new int[size];
            Node current = head;
            for (int i = 0; i < size; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
