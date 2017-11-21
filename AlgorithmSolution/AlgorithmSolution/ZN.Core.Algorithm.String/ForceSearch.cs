using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.String
{
    /// <summary>
    /// 暴力子字符串查找
    /// </summary>
    public class ForceSearch
    {
        /// <summary>
        /// 暴力查找子字符串
        /// </summary>
        /// <param name="pat">模式字符串</param>
        /// <param name="txt">文本字符串</param>
        /// <returns></returns>
        public static int Search(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            for (int i = 0; i <= N - M; i++)
            {
                int j;
                for (j = 0; j < M; j++)
                {
                    if (txt[i + j] != pat[j])
                        break;
                }

                if (j == M) return i;
            }

            return -1;
        }

        /// <summary>
        /// 暴力子字符串查找另一种实现
        /// </summary>
        /// <param name="pat"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int Search1(string pat, string txt)
        {
            int j, M = pat.Length;
            int i, N = txt.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
            {
                if (txt[i] == pat[j]) j++;
                else
                {
                    i -= j;
                    j = 0;
                }
            }
            if (j == M) return i - M;
            else return -1;
        }
    }
}
