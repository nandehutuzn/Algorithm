using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class Selection : Example
    {
        /// <summary>
        /// 将a[]按升序排列
        /// </summary>
        /// <param name="a"></param>
        public override void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {//将a[i]和a[i+1...N]中的最小元素交换
                int min = i;//最小元素索引
                for (int j = i + 1; j < N; j++)
                {
                    if (Less(a[j], a[min])) 
                        min = j;
                }
                Exch(a, i, min);
            }
        }
    }
}
