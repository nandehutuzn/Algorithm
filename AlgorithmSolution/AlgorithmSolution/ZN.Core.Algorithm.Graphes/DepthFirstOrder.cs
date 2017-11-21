using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 有向图中基于深度优先搜索的顶点排序
    /// </summary>
    public class DepthFirstOrder
    {
        private bool[] marked;
        /// <summary>
        /// 所有顶点的前序排列
        /// </summary>
        private Queue<int> pre;

        /// <summary>
        /// 所有顶点的后序排列
        /// </summary>
        private Queue<int> post;

        /// <summary>
        /// 所有顶点的逆后序排列
        /// </summary>
        private Stack<int> reversePost;

        public DepthFirstOrder(Digraph g)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[g.V];
            for (int i = 0; i < g.V; i++)
                if (!marked[i])
                    Dfs(g, i);
        }

        private void Dfs(Digraph g, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (int w in g.Adj(v))
            {
                if (!marked[w])
                    Dfs(g, w);
            }

            post.Enqueue(v);
            reversePost.Push(v);
        }

        /// <summary>
        /// 所有顶点的前序排列
        /// </summary>
        /// <returns></returns>
        public int[] Pre()
        {
            return pre.ToArray();
        }

        /// <summary>
        /// 所有顶点的后序排列
        /// </summary>
        /// <returns></returns>
        public int[] Post()
        {
            return post.ToArray();
        }

        /// <summary>
        /// 所有顶点的逆后序排列
        /// </summary>
        /// <returns></returns>
        public int[] ReversePost()
        {
            return reversePost.ToArray();
        }
    }
}
