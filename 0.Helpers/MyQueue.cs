public class QueueNode<T>
    {
        public T data;
        public QueueNode<T> next;

        public QueueNode(T data)
        {
            this.data = data;
        }
    }

    public class MyQueue<T>
    {
        public QueueNode<T> first;
        public QueueNode<T> last;
        public int size;

        public MyQueue()
        {
            size = 0;
        }

        public T pop()
        {
            if (first == null) 
                throw new Exception("Empty Queue");
            T item = first.data;
            first = first.next;
            size--;
            if (first == null)
                last = null;
            return item;
        }

        public void push(T item)
        {
            QueueNode<T> t = new QueueNode<T>(item);
            if (last != null)
                last.next = t;
            last = t;
            if (first == null)
                first = last;
            
        }

        public T peek()
        {
            if (first == null)
                throw new Exception("Empty Queue");
            return first.data;
        }

        public bool isEmpty()
        {
            return first == null;
        }

        public void Display()
        {
            while (first != null)
            {
                Console.Write($"{first.data} ");
               first = first.next;
            }
        }
    }