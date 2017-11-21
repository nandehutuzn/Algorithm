using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 堆排序   by zhangning  20170708
    /// </summary>
    public class Heap : Example
    {
        private IComparable[] pq;

        public override void Sort(IComparable[] a)
        {
            int N = a.Length;

            for (int k = 1; k < N; k++)
            {
                Swim(a, k); //将a[] 变成完全二叉堆，之后最大元素位于a[0]
            }

            while (--N > 1)
            {
                Exch(a, 0, N); //将最大元素挪到a[N]
                Sink(a, 0, N); //重新排列二叉树
            }

        }

        /// <summary>
        /// 由上至下的堆有序化（下沉）
        /// 某个节点比两个子节点或是其中之一更小了而被打破了，那么我们可以通过将它和它的两个子节点中较大者
        /// 交换来恢复堆
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="nLen"></param>
        private void Sink(IComparable[] a, int i, int nLen)
        {
            while (2 * i + 2 < nLen)
            {
                int j = 2 * i + 1;
                if (j < nLen && Less(a[j], a[j + 1])) j++;
                if (!Less(a[i], a[j])) break;
                Exch(a, i, j);
                i = j;
            }

        }

        /// <summary>
        /// 由下至上的堆有序化（上浮） 
        /// 父节点必须比子节点大  k节点父节点为(k-1)/2
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        private void Swim(IComparable[] a, int k)
        {
            while (k > 0 && Less(a[(k-1) / 2], a[k]))
            {
                Exch(a, (k-1) / 2, k);
                k = (k-1) / 2;
            }
        }
    }
}
