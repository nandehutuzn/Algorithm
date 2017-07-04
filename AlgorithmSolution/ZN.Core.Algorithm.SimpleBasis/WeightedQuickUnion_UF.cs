using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    public class WeightedQuickUnion_UF : UnionFind
    {
        private int[] sz; //(由触点索引的)各个根节点所对应的分量大小

        public WeightedQuickUnion_UF(int N)
            : base(N)
        {
            sz = new int[N];
            for (int i = 0; i < N; i++)
                sz[i] = 1;
        }

        public override int Find(int p)
        {
            //跟随链接找到根节点
            while (p != id[p]) p = id[p];

            return p;
        }

        public override void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;
            //将小树的根节点链接到大树的根节点
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            count--;
        }
    }
}
