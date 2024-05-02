namespace boruvkuv_algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  Graph g = new Graph(4);
              g.AddEdge(0, 1, 10);
              g.AddEdge(0, 2, 6);
              g.AddEdge(0, 3, 5);
              g.AddEdge(1, 3, 15);
              g.AddEdge(2, 3, 4); */

            Graph g = new Graph(12);
            g.AddEdge(0, 1, 13);
            g.AddEdge(0, 2, 6);
            g.AddEdge(1, 2, 7);
            g.AddEdge(1, 3, 1);
            g.AddEdge(2, 3, 14);
            g.AddEdge(2, 4, 8);
            g.AddEdge(2, 7, 20);
            g.AddEdge(3, 4, 9);
            g.AddEdge(3, 5, 3);
            g.AddEdge(4, 5, 2);
            g.AddEdge(4, 9, 18);
            g.AddEdge(6, 7, 15);
            g.AddEdge(6, 8, 5);
            g.AddEdge(6, 9, 19);
            g.AddEdge(6, 10, 10);
            g.AddEdge(7, 9, 17);
            g.AddEdge(8, 10, 11);
            g.AddEdge(9,10, 16);
            g.AddEdge(9, 11, 4);
            g.AddEdge(10, 11, 12);











            g.BoruvkaAlgorithm();
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

                    for (int i = 0; i < graph.Count; i++)  //Pro každou hranu se zjišťuje, zda spojuje dvě různé komponenty grafu. Pokud ano, porovnává se cena této hrany s cenou uloženou v seznamu cheapest pro příslušné komponenty
                    {
                        int u = graph[i][0];
                        int v = graph[i][1];
                        int w = graph[i][2]; //načítání hodnot z grafu

                        int set1 = Find(parent, u);
                        int set2 = Find(parent, v); //najdi do jaké množiny prvky patří


                        if (set1 != set2) //pokud se nerovnají assetni nejmenší cenu
                        {
                            if (cheapest[set1][2] == -1
                                || cheapest[set1][2] > w)
                            {
                                cheapest[set1]
                                    = new List<int> { u, v, w };
                            }
                            if (cheapest[set2][2] == -1
                                || cheapest[set2][2] > w)
                            {
                                cheapest[set2]
                                    = new List<int> { u, v, w };
                            }
                        }








                    }

                    for (int node = 0; node < V; node++)
                    {

                        // Check jestli nejlevnější pro current set existuje
                        if (cheapest[node][2] != -1)
                        {
                            int u = cheapest[node][0],
                                v = cheapest[node][1],
                                w = cheapest[node][2];
                            int set1 = Find(parent, u),
                                set2 = Find(parent, v);  //najde do jake množiny dva prvky patří
                            if (set1 != set2)
                            {
                                TotalPrice += w;
                                UnionSet(parent, rank, set1, set2); //pokud není stejná spoj je
                                Console.WriteLine(
                                    "Edge {0}-{1} with weight {2} included in MST",
                                    u, v, w);
                                numTrees--;
                            }
                        }
                    }

                    for (int node = 0; node < V; node++)
                    {
                        // reset cheapest array
                        cheapest[node][2] = -1;
                    }

                }

                Console.WriteLine("Weight of MST is {0}",
                          TotalPrice); //vypiš celkovou cenu





            }
             // funkce, která spojuje dvě množiny x a y
            private void UnionSet(List<int> parent, List<int> rank,
                         int x, int y)
            {
                int xroot = Find(parent, x);
                int yroot = Find(parent, y); //najdí kořeny obou množin

              
                if (rank[xroot] < rank[yroot]) //menší strom zapiš pod větší 
                {
                    parent[xroot] = yroot;
                }
                else if (rank[xroot] > rank[yroot])
                {
                    parent[yroot] = xroot;
                }

              
                else //pokud mají stejný rank, vyber jeden a zvětši rank
                {
                    parent[yroot] = xroot;
                    rank[xroot]++;
                }
            }

            private int Find(List<int> parent, int i) // prijima seznam rodicu,  jestliže prvek ukazuje na sebe je kořen svého stromu, pokud ne najde rodiče a vrátí kořen
            {
                if (parent[i] == i)
                {
                    return i;
                }
                return Find(parent, parent[i]);
            }

        }
    }
}
