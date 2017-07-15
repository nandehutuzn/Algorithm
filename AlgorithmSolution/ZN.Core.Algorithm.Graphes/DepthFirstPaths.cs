using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 使用深度优先搜索查找图中的路径
    /// </summary>
    public class DepthFirstPaths : Paths
    {
        /// <summary>
        /// 这个顶点上调用过Dfs(）了吗
        /// </summary>
        private bool[] marked;

        /// <summary>
        /// 从起点到一个顶点的已知路上的最后一个顶点
        /// </summary>
        private int[] edgeTo;

        /// <summary>
        /// 起点
        /// </summary>
        private int s;

        public DepthFirstPaths(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            Dfs(g, s);
        }

        /// <summary>
        /// 深度优先搜索
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void Dfs(Graph g, int v)
        {
            marked[v] = true; //该顶点被查找过
            foreach (int w in g.Adj(v)) //遍历与该顶点相邻的所有顶点
            {
                if (!marked[w])//如果该顶点还没有被查找（标记）
                {
                    edgeTo[w] = v;//记录该顶点路径的上一个顶点
                    Dfs(g, w);
                }
            }
        }

        /// <summary>
        /// 是否存在从s 到 v的路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public override bool HasPathTo(int v)
        {
            return marked[v];
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
    }
}
