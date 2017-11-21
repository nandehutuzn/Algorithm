using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.Sort;

namespace ZN.Core.Algorithm.String
{
    /// <summary>
    /// 高位优先的字符串排序  by zhangning  20170720
    /// </summary>
    public class MSD
    {
        /// <summary>
        /// 基数
        /// </summary>
        private static int R = 256;

        /// <summary>
        /// 小数组的切换阀值
        /// </summary>
        private static int M = 15;

        /// <summary>
        /// 数据分类的辅助数组
        /// </summary>
        private static string[] aux;

        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
                return s[d];
            else return -1;
        }

        public static void Sort(string[] a)
        {
            int N = a.Length;
            aux = new string[N];
            Sort(a, 0, N - 1, 0);
        }

        /// <summary>
        /// 以第d个字符为键将a[lo]至a[hi]排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <param name="d"></param>
        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo + M)
            {
                new Insertion().Sort(a);
                return;
            }

            int[] count = new int[R + 2];  //计算频率
            for (int i = lo; i <= hi; i++)
                count[CharAt(a[i], d) + 2]++;

            for (int r = 0; r < R + 1; r++)  //将频率转换为索引
                count[r + 1] += count[r];

            for (int i = lo; i <= hi; i++)//数据分类
                aux[count[CharAt(a[i], d) + 1]++] = a[i];

            for (int i = lo; i <= hi; i++)
                a[i] = aux[i - lo];

            for (int r = 0; r < R; r++)//递归的以每个字符为键进行排序
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }
    }
}
