using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 计算强连通分量的Kosaraju算法  by zhangning  20170718
    /// 使用深度优先搜索查找给定有向图G的反向图Gr，根据由此得到的所有顶点的逆后序再次用深度优先搜索处理有向图G（Kosaraju算法）
    /// 其构造函数中的每一次递归调用所标记的顶点都在同一个强连通分量之中
    /// </summary>
    public class KosarajuSCC
    {
        /// <summary>
        /// 已访问过的顶点
        /// </summary>
        private bool[] marked;

        /// <summary>
        /// 强连通分量的标志
        /// </summary>
        private int[] id;

        /// <summary>
        /// 强连通的数量
        /// </summary>
        private int Count { get; set; }

        public KosarajuSCC(Digraph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            DepthFirstOrder order = new DepthFirstOrder(g.Reverse());
            foreach (int s in order.ReversePost())
            {
                if (!marked[s])
                {
                    Dfs(g, s);
                    Count++;
                }
            }
        }

        private void Dfs(Digraph g, int v)
        {
            marked[v] = true;
            id[v] = Count;
            foreach (int w in g.Adj(v))
            {
                if (!marked[w])
                    Dfs(g, w);
            }
        }

        public bool StronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }
    }
}
