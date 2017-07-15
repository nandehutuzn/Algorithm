using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Graphes
{
    /// <summary>
    /// 路径API   by  zhangning 20170715
    /// </summary>
    public abstract class Paths
    {
        public abstract bool HasPathTo(int v);

        public abstract int[] PathTo(int v);
    }
}
