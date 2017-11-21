using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 在给定的一组数据中，所有和为0的整数对的数量   20170702   by zhangning
    /// </summary>
    public class SumFast
    {
        /// <summary>
        /// 在给定的一组数据中，所有和为0的整数对的数量
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int TwoSumCount(int[] a)
        {
            Array.Sort(a);
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (Foreword.Rank(-a[i], a) > i)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// 线性级别  两个数和为0组合
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int TwoSumCountPro(int[] a)
        {
            int count = 0;
            Array.Sort(a);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!dic.ContainsKey(a[i]))
                    dic.Add(a[i], 1);
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < 0 && dic.ContainsKey(-a[i]))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 所有三个数和为0的组合数
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ThreeSumCount(int[] a)
        {
            Array.Sort(a);
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Foreword.Rank(-(a[i] + a[j]), a) > j)
                        count++;
                }
            }
            return count;
        }
    }
}
