using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 快速排序法   by zhangning 20170708
    /// </summary>
    public class Quick : Example
    {
        public override void Sort(IComparable[] a)
        {
            
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi); //切分
            Sort(a, lo, j - 1); //将左半部分a[lo...j-1]排序
            Sort(a, j + 1, hi); //将有半部分a[j+1...hi]排序
        }

        /// <summary>
        /// 切分
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        private int Partition(IComparable[] a, int lo, int hi)
        {//将数组切分为a[lo...i-1], a[i],  a[i+1...hi]
            int i = lo, j = hi + 1;  //左右扫描指针
            IComparable v = a[lo];  //切分元素
            while (true)
            {  //扫描左右，检查扫描是否结束并交换元素
                while (Less(a[++i], v))
                {
                    if (i == hi)
                        break;
                }

                while (Less(v, a[--j]))
                {
                    if (j == lo)
                        break;
                }

                if (i >= j)
                    break;
                Exch(a, i, j);
            }

            Exch(a, lo, j);//将v=a[j] 放入正确的位置
            return j; // a[lo...j-1] <= a[j] <= a[j+1...hi]达成
        }
    }
}
