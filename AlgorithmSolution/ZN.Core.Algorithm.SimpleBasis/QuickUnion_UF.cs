using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 和quick-find算法互补
    /// </summary>
    public class QuickUnion_UF :UnionFind
    {
        public QuickUnion_UF(int N)
            : base(N)
        { 
        
        }

        /// <summary>
        /// 一开始Find(p)返回p,但Union（2,3）后，Find（2）返回3， Find（3）返回也3
        /// 我们从给定的触点开始，由它链接得到另一个触点，再由这个触点的链接到达第三个触点，如此继续跟随着链接直到到达
        /// 一个根触点(id[root]=root) ,且这个根触点必然存在
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override int Find(int p)
        {
            //找出分量名称
            while (p != id[p]) p = id[p];
            return p;
        }

        public override void Union(int p, int q)
        {
            //将p和q的根节点统一
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot) return;

            id[pRoot] = qRoot;
            count--;
        }
    }
}
