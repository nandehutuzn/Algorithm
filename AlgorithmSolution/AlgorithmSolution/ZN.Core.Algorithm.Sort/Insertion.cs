using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    public class Insertion : Example
    {
        /// <summary>
        /// 将a[]按升序排列
        /// </summary>
        /// <param name="a"></param>
        public override void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
            {//将a[i] 插入到 a[i-1],a[i-2],a[i-3]...之中
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    Exch(a, j, j - 1);
            }
        }

        /// <summary>
        /// 改进版插入排序
        /// </summary>
        /// <param name="a"></param>
        public void SortPro(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
            {
                IComparable max = a[i];
                for (int j = i; j > 0 && Less(max, a[j - 1]); j--)
                    max = a[j - 1];
                a[i] = max;
            }
        }
    }
}
