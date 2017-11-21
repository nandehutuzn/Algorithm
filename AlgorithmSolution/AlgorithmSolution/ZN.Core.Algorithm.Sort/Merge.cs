using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 归并排序 (自顶向下)  by zhangning 20170707
    /// </summary>
    public class Merge : Example
    {
        private IComparable[] aux;//归并所需的辅助数组

        public override void Sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];//一次性分配空间
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        { //将数组a[lo...hi]排序
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);//将左半边排序
            Sort(a, mid + 1, hi);//将右半边排序
            MergeArray(a, lo, mid, hi);//归并结果
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
