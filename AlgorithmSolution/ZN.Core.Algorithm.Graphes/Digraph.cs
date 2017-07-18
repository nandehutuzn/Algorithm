using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.SimpleBasis;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 有向图  by zhangning  20170718
    /// </summary>
    public class Digraph
    {
        /// <summary>
        /// 顶点总数
        /// </summary>
        public int V { get; set; }

        /// <summary>
        /// 边的总数
        /// </summary>
        public int E { get; set; }

        private Bag<int>[] adj;

        public Digraph(int v)
        {
            V = v;
            E = 0;
            adj = new Bag<int>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new Bag<int>();
        }

        /// <summary>
        /// 增加由v指向w的一条边
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            E++;
        }

        /// <summary>
        /// 由v指出的边所连接的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int[] Adj(int v)
        {
            return adj[v].ToArray();
        }

        /// <summary>
        /// 该图的反向图
        /// </summary>
        /// <returns></returns>
        public Digraph Reverse()
        {
            Digraph r = new Digraph(V);
            for (int v = 0; v < V; v++)
            {
                foreach (var w in Adj(v))
                    r.AddEdge(w, v);
            }
            return r;
        }
    }
}
