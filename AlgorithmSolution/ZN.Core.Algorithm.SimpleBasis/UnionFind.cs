using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 动态连通性  by zhangning  20170704
    /// 连通性问题说明：输入一列整数对，其中每个整数都表示某一种类型的对象，一对整数p、q可以被理解为p和q是相连的
    /// 我们假设相连是一种等价关系。我们的目标是编写一个程序来过滤掉序列中无意义的整数对（两个整数均来自于同一个等价类中）
    /// 比如输入（1,4）、（2,4）、（1,2）  则（1,2）就是无意义的对
    /// </summary>
    public abstract class UnionFind
    {
        protected int[] id; //分量id（以触点作为索引）
        protected int count;// 分量数量

        public UnionFind(int N)
        {//初始化分量id数组
            count = N;
            id = new int[N];
            for (int i = 0; i < N; i++)
                id[i] = i;
        }

        /// <summary>
        /// 连同分量的数量
        /// </summary>
        /// <returns></returns>
        public int Count() { return count; }

        /// <summary>
        /// 如果p和q存在于同一个分量则返回true
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q) { return Find(p) == Find(q); }
        
        /// <summary>
        /// p（0~N-1）所在的分量的标示符
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract int Find(int p);

        /// <summary>
        /// 在p和q之间添加一条连接
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public abstract void Union(int p, int q);
    }
}
