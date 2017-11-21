using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 有向图的可达性（深度优先）   by zhangning 20170718
    /// </summary>
    public class DirectedDFS : Paths
    {
        private bool[] marked;
        private int s;

        /// <summary>
        /// 从起点到一个顶点的已知路上的最后一个顶点
        /// </summary>
        private int[] edgeTo;

        public DirectedDFS(Digraph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            Dfs(g, s);
        }

        private void Dfs(Digraph g, int v)
        {
            marked[v] = true;
            foreach (int w in g.Adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;//记录该顶点路径的上一个顶点
                    Dfs(g, w);
                }
            }
        }

        /// <summary>
        /// s 到v的路径,如果不存在则返回null
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public override int[] PathTo(int v)
        {
            if (!HasPathTo(v)) return null;

            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
                path.Push(x);
            path.Push(s);

            return path.ToArray();
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }
    }
}
