using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 三向切分快速排序   by zhangning  20170708
    /// 三部分分别对应小于、等于、和大于切分元素的数组元素，普通的快速排序中并没有单独处理等于切分元素的数组
    /// </summary>
    public class Quick3Way : Example
    {
        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            int lt = lo, i = lo + 1, gt = hi;
            IComparable v = a[lo];

            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) Exch(a, lt++, i++);
                else if (cmp > 0) Exch(a, i, gt--);
                else i++;
            } //现在a[lo...lt-1] < v = a[lt...gt] < a[gt+1...hi]成立
            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }
    }
}
