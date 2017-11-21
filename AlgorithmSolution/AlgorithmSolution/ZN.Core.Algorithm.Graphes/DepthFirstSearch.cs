using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 深度优先搜索   by zhangning   20170715
    /// </summary>
    public class DepthFirstSearch
    {
        /// <summary>
        /// 各顶点是否被标记
        /// </summary>
        private bool[] marked;
        public int Count { get; set; }

        public DepthFirstSearch(Graph g, int s)
        {
            marked = new bool[g.V];
            Dfs(g, s);
        }

        private void Dfs(Graph g, int v)
        {
            marked[v] = true;
            Count++;
            foreach (int w in g.Adj(v))
            {
                if (!marked[w])
                    Dfs(g, w);
            }
        }

        /// <summary>
        /// 初始化传入顶点与w是否连通
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Marked(int w)
        {
            return marked[w];
        }
    }
}
