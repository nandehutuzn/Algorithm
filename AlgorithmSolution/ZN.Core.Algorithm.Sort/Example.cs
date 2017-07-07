using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 排序算法模板类   by zhangning   20170705
    /// </summary>
    public abstract class Example
    {
        public abstract void Sort(IComparable[] a);

        public static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        public static void Exch(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        /// <summary>
        /// 在单行中打印数组
        /// </summary>
        /// <param name="a"></param>
        public static void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// 测试数组元素是否有序
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool IsSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (Less(a[i], a[i - 1])) return false;
            return true;
        }
    }
}
