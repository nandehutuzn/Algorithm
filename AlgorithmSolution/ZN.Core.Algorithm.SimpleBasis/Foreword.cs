using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// by zhangning   2017.6.29
    /// </summary>
    public class Foreword
    {
        /// <summary>
        /// 求最大公约数
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int GetMaxCommonDivisor(int p, int q)
        {
            if (q == 0) return p;
            return GetMaxCommonDivisor(q, p % q);
        }

        /// <summary>
        /// 二分查找法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="a">有序数组</param>
        /// <returns></returns>
        public static int Rank(int key, int[] a)
        {
            int low = 0;
            int high = a.Length - 1;
            while (low <= high)
            {//被查找的键要么不存在，要么必然存在于 a[low...high]中
                int mid = low + (high - low) / 2;
                if (key < a[mid]) high = mid - 1;
                else if (key > a[mid]) low = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}
