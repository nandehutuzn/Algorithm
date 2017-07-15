using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.Graphes;

namespace ZN.Core.Algorithm.GraphesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = GetGraph();
            int[] paths;
            Paths path;
            path = new DepthFirstPaths(g, 0);
            paths = path.PathTo(4);

            path = new BreadthFirstPaths(g, 0);
            paths = path.PathTo(4);

            Console.ReadKey();
        }

        private static Graph GetGraph()
        {
            Graph g = new Graph(6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(2, 1);
            g.AddEdge(2, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 4);
            g.AddEdge(3, 5);

            return g;
        }
    }
}
