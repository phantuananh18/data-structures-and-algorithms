public class StackNode<T>
    {
        public T data;
        public StackNode<T> next;

        public StackNode(T data)
        {
            this.data = data;
        }
    }

    public class MyStack<T>
    {
        public StackNode<T> top;
        public int size;

        public MyStack()
        {
            size = 0;
        }

        public T pop()
        {
            if (top == null)
                throw new Exception("Empty Stack");
            T item = top.data;
            top = top.next;
            size--;
            return item;
        }

        public void push(T item)
        {
            StackNode<T> t = new StackNode<T>(item);
            t.next = top;
            top = t;
            size++;
        }

        public T peek()
        {
            if (top == null)
                throw new Exception("Empty Stack");
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }

        public void Display()
        {
            while(top != null)
            {
                Console.Write($"{top.data}--> ");
                top = top.next;
            }
        }
    }