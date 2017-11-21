using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 有向环   by  zhangning  20170718
    /// </summary>
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;

        /// <summary>
        /// 有向环中的所有顶点（如果存在的话）
        /// </summary>
        private Stack<int> cycle;
        /// <summary>
        /// 递归调用的栈上的所有顶点
        /// </summary>
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            onStack = new bool[g.V];
            edgeTo = new int[g.V];
            marked = new bool[g.V];
            for (int v = 0; v < g.V; v++)
                if (!marked[v])
                    Dfs(g, v);
        }

        private void Dfs(Digraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (int w in g.Adj(v))
            {
                if (HasCycle()) return;
                else if (!marked[v])
                {
                    edgeTo[w] = v;
                    Dfs(g, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x])
                    {
                        cycle.Push(x);
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
            
        }

        /// <summary>
        /// g是否含有有向环
        /// </summary>
        /// <returns></returns>
        public bool HasCycle()
        {
            return cycle != null;
        }

        /// <summary>
        /// 有向环中的所有顶点
        /// </summary>
        /// <returns></returns>
        public int[] Cycle()
        {
            return cycle.ToArray();
        }
    }
}
