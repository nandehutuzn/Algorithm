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

        /// <summary>
        /// 获取斐波那契数列
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] GetFibonacciPro(int n)
        {
            int[] f = new int[n];
            for (int i = 0; i < n; i++)
                f[i] = (int)FibonacciPro(i);
            return f;
        }

        /// <summary>
        /// 找出数组a中最接近的一对
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Tuple<double, int, int> SearchNearestValue(double[] a)
        {
            Array.Sort(a);
            double minValue = double.MaxValue;
            int index1 = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i + 1] - a[i] < minValue)
                {
                    minValue = a[i + 1] - a[i];
                    index1 = i;
                }
            }

            return new Tuple<double, int, int>(minValue, index1, index1 + 1);
        }

        /// <summary>
        /// 斐波那契查找，运行时间  LogN
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int FibonacciSearch(int key, int[] data)
        {
            int low = 0;
            int high = data.Length - 1;
            int mid = 0;

            //斐波那契分割值下标
            int k = 0;

            //序列元素个数
            int i = 0;

            //获取斐波那契数列 0,1,1,2,3,5,8,13,21,34,55...
            int[] f = GetFibonacciPro(20);

            //获取斐波那契分割值下标
            while (data.Length > f[k] - 1)
                k++;

            //创建临时数组
            int[] temp = new int[f[k] - 1];
            for (int j = 0; j < data.Length; j++)
                temp[j] = data[j];

            //序列补充至f[k]个元素
            //补充的元素值为最后一个元素的值
            for (i = data.Length; i < f[k] - 1; i++)
                temp[i] = temp[high];

            while (low <= high)
            { 
                // low :起始位置
                // 获取 黄金分割位置元素的下标,所以这里是k-1 还是k-2 区别不大
                mid = low + f[k - 2] - 1;

                if (temp[mid] > key)
                {
                    //待查找元素在[low, mid-1]，高位指针移动
                    high = mid - 1;
                    //这里是 k-=1还是  k-=2并无太大差别，因为斐波那契数组每项值都等于前两项之和
                    //这和二分查找原理是一样的，二分查找是把剩下部分五五开，而斐波那契查找是把剩下部分分成
                    //其在斐波那契数列中前一项和前两项
                    k = k - 2;
                }
                else if (temp[mid] < key)
                {
                    //待查找元素在[mid+1,high]  低位指针移动
                    low = mid + 1;
                    k = k - 1;
                }
                else
                {
                    if (mid <= high) return mid;
                    else
                    {
                        // 出现这种情况是查找到补充的元素
                        // 而补充的元素与high位置的元素一样
                        return high;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 两个鸡蛋，某楼层以上鸡蛋全碎，以下全不碎，找出这个楼层
        /// （如果有无数鸡蛋，则可用二分查找法，从先从floors/2层开始，没碎再从上面一般层开始，碎了就从下面一般层开始）
        /// </summary>
        /// <param name="floors"></param>
        /// <returns></returns>
        public static int ThrowEggs(int floors)
        {
            //假设最少次数为x，则第一个鸡蛋从第x层扔（不管碎没碎，还有x-1次尝试机会）。
            //如果碎了，则在1~x-1层中线性搜索索x-1次，如果没碎，则第二次从x+(x-1)层扔（现在还有x-2次尝试机会）
            //如果这次碎了，则在x+1～x+(x-1)-1层中线性搜索，最多x-2次,如果还没碎第一个鸡蛋再从x+(x-1)+(x-2)层扔，依此类推
            //x次尝试所能确定的最高楼层数为x+(x-1)+(x-2)+...+1=x(x+1)/2。
            int x = 1; //最少次数
            while ((x * (x + 1)) / 2 < floors)
                x++;
            return x;
        }
    }
}
