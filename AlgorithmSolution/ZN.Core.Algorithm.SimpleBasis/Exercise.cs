using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 第一章练习
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// 整型转换成二进制字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToBinaryString(int num)
        {
            string s = "";
            for (int i = num; i > 0; i /= 2)
                s = i % 2 + s;
            return s;
        }

        /// <summary>
        /// 返回大小为参数m的数组，其中第i个元素的值为整数i在参数数组中出现的次数
        /// </summary>
        /// <param name="array"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int[] Histogram(int[] array, int m)
        {
            int[] result = new int[m];
            Array.Sort(array);//先对该数组排序
            for (int i = 0; i < m; i++)
            {
                int index = Foreword.Rank(i + 1, array);//用二分查找法找出该数在数组中的位置
                if (index == -1) result[i] = 0;
                else result[i] = GetCountInSortedArray(array, index);
            }

            return result;
        }

        /// <summary>
        /// 在已排好序的数组中查询与索引为index相同值的数的个数
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int GetCountInSortedArray(int[] array, int index)
        {
            int count = 0;
            for (int i = index; i < array.Length; i++)
            {
                if (array[index] == array[i]) count++;
                else break;
            }
            for (int i = index - 1; i > 0; i--)
            {
                if (array[index] == array[i]) count++;
                else break;
            }

            return count;
        }

        /// <summary>
        /// a*b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int MyStery(int a, int b)
        {
            if (b == 0) return 0;
            if (b % 2 == 0) return MyStery(a + a, b / 2);
            return MyStery(a + a, b / 2) + a;
        }

        /// <summary>
        /// 斐波那契数列
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// 斐波那契数列  改进版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long FibonacciPro(int n)
        {
            if (n <= 0)
                return n;
            long a = 1;
            long b = 1;
            for (int i = 3; i <= n; i++)
            {
                b = a + b;
                a = b - a;
            }
            return b;
        }
    }
}
