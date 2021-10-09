//Implement 3 stacks using only 1 array.
public class MultiStack<T>
    {
        public int NumberOfStack;
        public int CapacityOfStack;
        List<int> sizes;
        List<T> values;

        public MultiStack(int fullsize, int n)
        {
            CapacityOfStack = fullsize;
            this.NumberOfStack = n;
            this.values = new List<T>(fullsize * n);
            this.sizes = new List<int>(n);

            for (int i = 0; i < n; i++)
                sizes.Add(0);
            for (int i = 0; i < fullsize; i++)
                values.Add(default(T));
        }

        public int getTopIndex(int whichStack)
        {
            int offset = whichStack * CapacityOfStack;
            int size = sizes[whichStack];
            return offset + size - 1;
        }

        public bool isFull(int whichStack)
        {
            return this.sizes[whichStack] == CapacityOfStack;
        }

        public bool isEmpty(int whichStack)
        {
            return this.sizes[whichStack] == 0;
        }

        public void push(int whichStack, T value)
        {
            if (isFull(whichStack)) return;
            sizes[whichStack]++;
            values[getTopIndex(whichStack)] = value;
        }
        
        public T peek(int whichStack)
        {
            if (isEmpty(whichStack)) 
                throw new Exception("Empty Queue");
            return this.values[getTopIndex(whichStack)];
        }

        public T pop(int whichStack)
        {
            if (isEmpty(whichStack))
                throw new Exception("Empty Queue");
            int topIndex = getTopIndex(whichStack);
            T currentTopValue = values[topIndex];
            values[topIndex] = default(T);
            sizes[whichStack]--;
            return currentTopValue;
        }
    }