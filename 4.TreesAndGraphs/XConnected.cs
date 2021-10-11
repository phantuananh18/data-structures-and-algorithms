//Cho đơn đồ thị vô hướng G=(V,E) và một đỉnh x. Hãy cho biết từ đỉnh x có thể đi đến những đỉnh nào bằng thuật toán DFS
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

        //Duyet cay theo DFS    
        public void DFS(int x)
        {
            vistited[x] = true;
            foreach(int z in adjagency[x])
            {
                if (vistited[z] == false)
                {
                    Console.WriteLine(z);
                    DFS(z);
                }
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
            graph.DFS(2);
            Console.ReadKey();
        }
    }