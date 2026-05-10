namespace LinkedLists
{
    public class Node<T>
    {
        // attributes
        public T Data { get; set; }

        public Node<T>? Next;
        public Node<T>? Prev;

        // Constructor
        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}