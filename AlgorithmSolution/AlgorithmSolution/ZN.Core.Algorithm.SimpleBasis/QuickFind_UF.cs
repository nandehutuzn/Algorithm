using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// Find操作速度很快，但Union速度一般，每一对输入都需要扫描整个id[]数组
    /// </summary>
    public class QuickFind_UF : UnionFind
    {
        public QuickFind_UF(int N)
           : base(N)
        { 
        
        }

        public override int Find(int p)
        {
            return id[p];
        }

        public override void Union(int p, int q)
        {//将pq归并到相同的分量当中
            int pID = Find(p);
            int qID = Find(q);

            if (pID == qID) return;//如果pq已在相同的分量当中，则不做任何处理

            //将p的分量重命名为q的名称
            for (int i = 0; i < id.Length; i++)
                if (id[i] == pID) id[i] = qID;
            count--;
        }
    }
}
