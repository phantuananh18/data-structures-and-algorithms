//Xây dựng và duyệt BST theo 3 cách khác nhau : LNR,LRN,NLR.
class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T data)
        {
            this.data = data;
            left = right = null;
        }

        //InOrder Traversal ->LNR
        public void InOrderTraversal(Node<T> root)
        {
            if (root == null) return;
            InOrderTraversal(root.left);
            Console.Write($"{root.data} ");
            InOrderTraversal(root.right);
        }

        //PreOrder Traversal ->NLR
        public void PreOrderTraversal(Node<T> root)
        {
            if (root == null) return;
            Console.Write($"{root.data} ");
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        //PostOrder Traversal ->LRN
        public void PostOrderTraversal(Node<T> root)
        {
            if (root == null) return;
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.Write($"{root.data} ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(2);
            node.left = new Node<int>(7);
            node.right = new Node<int>(5);
            node.left.left = new Node<int>(2);
            node.left.right = new Node<int>(6);
            node.right.right = new Node<int>(9);
            node.left.right.left = new Node<int>(5);
            node.left.right.right = new Node<int>(11);
            node.right.right.left = new Node<int>(4);
            node.InOrderTraversal(node);
            Console.WriteLine();
            node.PreOrderTraversal(node);
            Console.WriteLine();
            node.PostOrderTraversal(node);
            Console.WriteLine();
            Console.ReadKey();
        }
    }