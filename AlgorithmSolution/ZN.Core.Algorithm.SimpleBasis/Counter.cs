using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 计数器
    /// </summary>
    public class Counter
    {
        private string _name;
        private int _count;
        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        public Counter(string id)
        {
            _name = id;
        }

        public void Increment()
        {
            Interlocked.Increment(ref _count);
        }

        public int Tally()
        {
            return _count;
        }

        public override string ToString()
        {
            return _count + "  " + _name;
        }
    }
}
