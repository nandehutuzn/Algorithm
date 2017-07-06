using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 希尔排序
    /// 其思想是是数组中任意间隔为h的元素都是有序的，这样的数组被称为h有序数组
    /// </summary>
    public class Shell : Example
    {
        public override void Sort(IComparable[] a)
        {  //将a[]按升序排列
            int N = a.Length;
            int h = 1;
            while (h < N / 3)
                h = 3 * h + 1; //1,4,13,40,121,364

            while (h >= 1)
            { //将数组变为h有序
                for (int i = h; i < N; i++)
                { //将a[i]插入到a[i-2*h], a[i-3*h]。。。之中
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                        Exch(a, j, j - h);
                }
                h = h / 3;
            }
        }
    }
}
