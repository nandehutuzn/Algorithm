using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.String
{
    /// <summary>
    /// 低位优先的字符串排序   by zhangning  20170720
    /// </summary>
    public class LSD
    {
        /// <summary>
        /// 通过前w个字符将a[]排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="w"></param>
        public static void Sort(string[] a, int w)
        {
            int N = a.Length;
            int R = 256;
            string[] aux = new string[N];

            for (int d = w - 1; d >= 0; d--)
            { //根据第d个字符用键索引计数法排序

                int[] count = new int[R + 1];//计算出现频率
                for (int i = 0; i < N; i++)
                    count[a[i][d] + 1]++;

                for (int r = 0; r < R; r++) //将频率转换为索引
                    count[r + 1] += count[r];

                for(int i=0;i<N;i++)  //将元素分类
                    aux[count[a[i][d]]++] = a[i];

                for (int i = 0; i < N; i++) //回写
                    a[i] = aux[i];
            }
        }
    }
}
