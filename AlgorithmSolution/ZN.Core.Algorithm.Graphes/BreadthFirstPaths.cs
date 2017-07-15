using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 广度优先搜索查找图中的路径
    /// </summary>
    public class BreadthFirstPaths : Paths
    {
        /// <summary>
        /// 到达该顶点的最短路径是否已知
        /// </summary>
        private bool[] marked;

        /// <summary>
        /// 到达该顶点的已知路径上的最后一个顶点
        /// </summary>
        private int[] edgeTo;

        /// <summary>
        /// 起点
        /// </summary>
        private int s;

        public BreadthFirstPaths(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            Bfs(g, s);
        }

        /// <summary>
        /// 广度优先搜索
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void Bfs(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true; //标记起点
            queue.Enqueue(s);//将起点加入队列
            while (0 != queue.Count)
            {
                int v = queue.Dequeue();//从队列中删去下一顶点
                foreach (int w in g.Adj(v))
                {
                    if (!marked[w])//对于每个未被标记的相邻顶点
                    {
                        edgeTo[w] = v;//保存最短路径的最后一条边
                        marked[w] = true;//标记它，因为最短路径已知
                        queue.Enqueue(w);//并将它添加到队列中
                    }
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
