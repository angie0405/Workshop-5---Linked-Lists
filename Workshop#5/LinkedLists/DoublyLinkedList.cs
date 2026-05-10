using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedLists
{
    public class DoublyLinkedList<T> where T : IComparable
    {
        private Node<T>? Head;
        private Node<T>? Tail;

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        // Insert
        public void Insert(T Data)
        {
            Node<T> newNode = new Node<T>(Data);

            // Case 1 - Empty list
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            // Case 2 - goes to the beginning
            else if (Data.CompareTo(Head.Data) < 0)
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
            // case 3 - goes to the end
            else if (Data.CompareTo(Tail!.Data) > 0)
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
            // case 4 - goes in the middle
            else
            {
                Node<T>? actual = Head;

                while (actual != null && Data.CompareTo(actual.Data) > 0)
                {
                    actual = actual.Next;
                }

                if (actual == null)
                {
                
                    Tail!.Next = newNode;
                    newNode.Prev = Tail;
                    Tail = newNode;
                }
                else if (actual.Prev == null)
                {
                    
                    newNode.Next = Head;
                    Head!.Prev = newNode;
                    Head = newNode;
                }
                else
                {
                    
                    newNode.Next = actual;
                    newNode.Prev = actual.Prev;
                    actual.Prev.Next = newNode;
                    actual.Prev = newNode;
                }
            }
        }

        // PrintForward
        public void PrintForward()
        {
            Node<T>? actual = Head;
            while (actual != null)
            {
                Console.Write($"{actual.Data} ");
                actual = actual.Next;
            }
        }

        // PrintBackward
        public void PrintBackward()
        {
            Node<T>? actual = Tail;
            while (actual != null)
            {
                Console.Write(actual.Data + " ");
                actual = actual.Prev;
            }
            Console.WriteLine();
        }

        // SortDescending
        public void SortDescending()
        {
            Node<T>? actual = Head;

            while (actual != null)
            {
                Node<T>? temp = actual.Next;
                actual.Next = actual.Prev;
                actual.Prev = temp;
                actual = temp;
            }

            Node<T>? temp2 = Head;
            Head = Tail;
            Tail = temp2;
        }

        // GetModes
        public void GetMode()
        {
            if (Head == null)
            {
                Console.WriteLine("La lista esta vacia");
                return;
            }

            // Case 1 - Counting occurrences
            Dictionary<T, int> counts = new Dictionary<T, int>();
            Node<T>? actual = Head;
            while (actual != null)
            {
                if (counts.ContainsKey(actual.Data))
                    counts[actual.Data]++;
                else
                    counts[actual.Data] = 1;
                actual = actual.Next;
            }

            // Case 2 - Finding the maximum
            int max = 0;
            foreach (var kv in counts)
                if (kv.Value > max) max = kv.Value;

            // Case 3 - If none are repeated, there is no mode
            if (max <= 1)
            {
                Console.WriteLine("No hay moda en la lista");
                return;
            }

            // Case 4 - Show the trends
            Console.Write("Moda(s): ");
            foreach (var kv in counts)
                if (kv.Value == max)
                    Console.Write(kv.Key + " ");
            Console.WriteLine();
        }

        // PrintChart
        public void PrintChart()
        {
            if (Head == null)
            {
                Console.WriteLine("La lista esta vacia");
                return;
            }

            // Step 1 - Counting occurrences
            Dictionary<T, int> counts = new Dictionary<T, int>();
            Node<T>? actual = Head;
            while (actual != null)
            {
                if (counts.ContainsKey(actual.Data))
                    counts[actual.Data]++;
                else
                    counts[actual.Data] = 1;
                actual = actual.Next;
            }

            // Step 2 - Display in order by traversing the list
            Node<T>? current = Head;
            while (current != null)
            {
                //Step 3 - Only prints the first time it appears
                if (counts.ContainsKey(current.Data))
                {
                    Console.Write(current.Data.ToString()!.PadRight(15));
                    for (int i = 0; i < counts[current.Data]; i++)
                        Console.Write("*");
                    Console.WriteLine();
                    counts.Remove(current.Data);
                }
                current = current.Next;
            }
        }

        //exists
        public bool Exists(T data)
        {
            Node<T>? actual = Head;
            while (actual != null)
            {
                if (actual.Data.Equals(data))
                    return true;
                actual = actual.Next;
            }
            return false;
        }

        //RemoveFirst
        public void RemoveFirst(T data)
        {
            Node<T>? actual = Head;

            while (actual != null)
            {
                if (actual.Data.Equals(data))
                {
                    // Case 1 - If it has a previous node
                    if (actual.Prev != null)
                        actual.Prev.Next = actual.Next;
                    else
                        Head = actual.Next;

                    // Case 2 - If it has a next node
                    if (actual.Next != null)
                        actual.Next.Prev = actual.Prev;
                    else
                        Tail = actual.Prev;

                    return;
                }
                actual = actual.Next;
            }
        }

        //RemoveAll
        public void RemoveAll(T data)
        {
            Node<T>? actual = Head;

            while (actual != null)
            {
                if (actual.Data.Equals(data))
                {
                    // Case 1 - If it has a previous node
                    if (actual.Prev != null)
                        actual.Prev.Next = actual.Next;
                    else
                        Head = actual.Next;

                    // Case 2 - If it has a next node
                    if (actual.Next != null)
                        actual.Next.Prev = actual.Prev;
                    else
                        Tail = actual.Prev;
                }
                actual = actual.Next;
            }
        }
    }
}