using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.String
{
    public class KMPSearch
    {
        private string _pat;
        private int[,] _dfa;

        public KMPSearch(string pat)
        {
            _pat = pat;
            int M = _pat.Length;
            int R = 256;
            _dfa = new int[R, M];
            _dfa[_pat[0], 0] = 1;

            for (int X = 0, j = 1; j < M; j++)
            { //计算dfa[,j]
                for (int c = 0; c < R; c++)
                {
                    _dfa[c, j] = _dfa[c, X]; //复制匹配失败情况下的值
                }

                _dfa[pat[j], j] = j + 1; //设置匹配成功情况下的值
                X = _dfa[pat[j], X];//更新重启状态
            }
        }

        public int Search(string txt)
        {
            int i, j, N = txt.Length, M = _pat.Length;

            for (i = 0, j = 0; i < N && j < M; i++)
            {
                j = _dfa[txt[i], j];
            }

            if (j == M) return i - M;
            else return -1;
        }

    }
}
