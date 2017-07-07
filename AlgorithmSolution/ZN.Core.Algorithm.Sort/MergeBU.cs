using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 归并排序  （自底向上）  by zhangning 20170707
    /// </summary>
    public class MergeBU : Example
    {
        private IComparable[] aux;//归并所需辅助数组

        public override void Sort(IComparable[] a)
        {
            int N = a.Length;
            aux = new IComparable[N];

            for (int sz = 1; sz < N; sz = sz + sz)  //sz子数组大小
            {
                for (int lo = 0; lo < N - sz; lo += sz + sz) //lo:子数组索引
                {
                    MergeArray(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
        }

        private void MergeArray(IComparable[] a, int lo, int mid, int hi)
        { //将a[lo...mid] 和a[mid+1...hi]归并
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)//将a[lo...hi] 复制到aux[lo...hi]中
                aux[k] = a[k];

            for (int k = lo; k <= hi; k++)  //归并回到a[lo...hi]
            {
                if (i > mid) a[k] = aux[j++];//左半边用尽，直接取右半边的元素
                else if (j > hi) a[k] = aux[i++];//右半边用尽，直接取左半边
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];//右半边的当前元素小于左半边的当前元素，取右半边元素
                else a[k] = aux[i++];//右半边当前元素大于左半边当前元素，直接取左半边当前元素
            }
        }
    }
}
