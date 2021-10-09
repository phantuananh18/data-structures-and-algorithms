//Cho đồ thị có hướng, hãy thiết kế một thuật toán để tìm xem có tuyến đường giữa hai nút hay không ?
class Graph
    {
        public bool[] vistited;
        public int nVertex;
        public List<int>[] adjagency;

        public Graph(int nVertex)
        {
            this.nVertex = nVertex;
            initialize();
        }

        public void initialize()
        {
            adjagency = new List<int>[nVertex + 10];
            for(int i = 0; i < nVertex; i++)
            {
                adjagency[i] = new List<int>();
            }
            vistited = new bool[nVertex + 10];
            for(int i = 0; i < nVertex; i++)
            {
                vistited[i] = false;
            }
        }

        //directed graph
        public void addDirectedEdge(int u,int v)
        {
            adjagency[u].Add(v);
        }

        //undirected graph
        public void addUndirectedEdge(int u,int v)
        {
            adjagency[u].Add(v);
            adjagency[v].Add(u);
        }

        //Duyet cay theo BFS
        public void BFS(int s)
        {
            vistited = new bool[nVertex + 10];
            for(int i = 0; i < nVertex; i++)
            {
                vistited[i] = false;
            }
            Queue<int> queue = new Queue<int>();
            vistited[s] = true;
            queue.Enqueue(s);
            Console.Write($"{s} ");

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                foreach(int x in adjagency[s])
                {
                    if (!vistited[x])
                    {
                        Console.Write($"{x} ");
                        vistited[x] = true;
                        queue.Enqueue(x);
                    }
                }
            }
        }

        public bool isVisited(int u,int v)
        {
            BFS(u);
            return vistited[u] == true && vistited[v] == true;
        }

        public void PrintGraph()
        {
            for(int i = 0; i < nVertex; i++)
            {
                Console.Write($"{i} ");
                if (adjagency[i].Count == 0)
                {
                    Console.Write($"NULL");
                }
                else
                {
                    foreach(int x in adjagency[i])
                    {
                        Console.Write($"{x} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.addDirectedEdge(0, 1);
            graph.addDirectedEdge(0, 2);
            graph.addDirectedEdge(1, 2);
            graph.addDirectedEdge(2, 0);
            graph.addDirectedEdge(2, 3);
            graph.addDirectedEdge(3, 3);
            graph.PrintGraph();
            Console.WriteLine(graph.isVisited(0, 3));
            Console.ReadKey();
        }
    }