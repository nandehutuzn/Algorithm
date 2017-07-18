using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 拓扑排序   by zhangning  20170718
    /// </summary>
    public class Topological
    {
        /// <summary>
        /// 顶点的拓扑排序
        /// </summary>
        public int[] Order { get; set; }

        public Topological(Digraph g)
        {
            DirectedCycle cyclefinder = new DirectedCycle(g);
            if (!cyclefinder.HasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(g);
                Order = dfs.ReversePost();//逆后序排列
            }
        }
    }
}
