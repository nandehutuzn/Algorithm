using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.SimpleBasis;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 无向图   by  zhangning   20170713
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// 顶点数目
        /// </summary>
        public int V{get;set;}  

        /// <summary>
        /// 边的数目
        /// </summary>
        public int E { get; set; }
        protected Bag<int>[] adj; // 邻接表

        public Graph(int v)
        {
            V = v;
            adj = new Bag<int>[V];  //创建邻接表
            for (int i = 0; i < V; i++) //初始化各个邻接表
                adj[i] = new Bag<int>();
        }

        /// <summary>
        /// 向途中添加一条边  v-w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            E++;
        }

        /// <summary>
        /// 和v相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int[] Adj(int v)
        {
            return adj[v].ToArray();
        }
    }
}
