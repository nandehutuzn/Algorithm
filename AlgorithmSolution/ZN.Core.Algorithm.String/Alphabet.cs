using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.String
{
    /// <summary>
    /// 字母表API   by zhangning  20170719
    /// </summary>
    public abstract class Alphabet
    {
        /// <summary>
        /// 基数（字母表中的字符数量）
        /// </summary>
        public int R { get; set; }

        public Alphabet(string s) { }

        /// <summary>
        /// 获取字母表中索引位置的字符
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract char ToChar(int index);

        /// <summary>
        /// 获取c的索引  在0~R-1之间
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public abstract int ToIndex(char c);

        /// <summary>
        /// c在字母表中吗
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public abstract bool Contains(char c);

        /// <summary>
        /// 表示一个索引所需的比特数
        /// </summary>
        /// <returns></returns>
        public int LgR()
        {
            return (int)Math.Ceiling(Math.Log(R, 2));
        }

        /// <summary>
        /// 将S转换为R进制的整数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public abstract int[] ToIndices(string s);

        /// <summary>
        /// 将R进制的整数转换为基于该字母表的字符串
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        public abstract string ToChars(int[] indices);
    }
}
