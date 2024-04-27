namespace boruvkuv_algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4);
            g.AddEdge(0, 1, 10);
            g.AddEdge(0, 2, 6);
            g.AddEdge(0, 3, 5);
            g.AddEdge(1, 3, 15);
            g.AddEdge(2, 3, 4);
        }

        class Graph
        {

            private int V; //počet vrcholů
            private List<List<int>> graph; //graf k algoritmu

            public Graph(int vrcholy) //konstruktor, zjistí počty vrcholů a založí graf
            {
                this.V = vrcholy;
                graph = new List<List<int>>();
            }

            public void AddEdge(int u, int v, int w) //přidání spojení u - z kterého, v - kam, w - cena
            {
                graph.Add(new List<int> { u, v, w });
            }

            public void BoruvkaAlgorithm() //spustí borůvkův algoritmus
            {
                List<int> parent = new List<int>(); // hlavní rodič


                List<int> rank = new List<int>();

                List<List<int>> cheapest = new List<List<int>>(); // ukládám nejlevnější cesty

                int numTrees = V; //nazačátku máme V stromů
                int TotalPrice = 0; //celková cena


                //založ V počet cest s 1 elementem
                for (int node = 0; node < V; node++)
                {
                    parent.Add(node);
                    rank.Add(0);
                    cheapest.Add(new List<int> { -1, -1, -1 });
                }

                while (numTrees > 1) //dokud nejsou všechny stromy spojené pokračuj
                {

                    for(int i = 0; i < graph.Count; i++)
                    {
                        int u = graph[i][0];
                        int v = graph[i][1];
                        int w = graph[i][2]; //načítání hodnot z grafu






                    }


                }







            }

        }
    }
}
