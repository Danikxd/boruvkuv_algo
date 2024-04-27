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

        }
    }
}
