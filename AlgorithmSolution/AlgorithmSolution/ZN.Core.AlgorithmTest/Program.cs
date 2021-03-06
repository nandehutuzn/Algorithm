﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ZN.Core.Algorithm.SimpleBasis;
using ZN.Core.Algorithm.Sort;

namespace ZN.Core.AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            /*
            
            //Console.WriteLine(Foreword.GetMaxCommonDivisor(100044, 44));
            //int[] whitelist = GetRandomArray(40000000);
            //Array.Sort(whitelist);
            Stopwatch watch = new Stopwatch();
            //watch.Start();
            //int index = Foreword.Rank(1000008, whitelist);
            //watch.Stop();
            //Console.WriteLine(index + watch.Elapsed.ToString());
            //Console.WriteLine(Exercise.IntToBinaryString(16));
            //int[] array = new int[] { 3, 5, 7, 1, 5, 8, 3, 6, 3, 8, 5, 9, 10, 4 };
            //int[] result = Exercise.Histogram(array, 11);
            //Console.WriteLine(Exercise.MyStery(5, 19));
            //for (int i = 0; i < 100; i++)
            //    Console.WriteLine(i + "   " + Exercise.Fibonacci(i));
            //for (int i = 0; i < 100; i++)
            //    Console.WriteLine(i + "   " + Exercise.FibonacciPro(i));

            ResizingArrayStack<int> intStack = new ResizingArrayStack<int>();
            watch.Start();
            for (int i = 0; i < 10000; i++)
                intStack.Push(i);
            watch.Stop();
            Console.WriteLine("ResizingArrayStack time: " + watch.Elapsed);
            
            //foreach (int i in intStack)
            //    Console.WriteLine(i);
            //for (int i = 0; i < 10; i++)
            //    Console.WriteLine(intStack.Pop());

            ZN.Core.Algorithm.SimpleBasis.Stack<int> stack = new Algorithm.SimpleBasis.Stack<int>();  //2017.7.1
            watch.Restart();
            for (int i = 0; i < 10000; i++)
                stack.Push(i);
            watch.Stop();
            Console.WriteLine("ListStack time: " + watch.Elapsed);

            //foreach (int i in stack)
            //    Console.WriteLine(i);
            //for (int i = 0; i < 10; i++)
            //    Console.WriteLine(stack.Pop());
            Console.WriteLine("------------------ListQueue-------------------");
            ZN.Core.Algorithm.SimpleBasis.Queue<int> queue = new Algorithm.SimpleBasis.Queue<int>();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(i);
            foreach (int i in queue)
                Console.WriteLine(i);
            for (int i = 0; i < 10; i++)
                Console.WriteLine(queue.Dequeue());

            ZN.Core.Algorithm.SimpleBasis.Stack<int> stackCopy = ZN.Core.Algorithm.SimpleBasis.Stack<int>.Copy(stack);

            Console.WriteLine("--------------------SumFast----------------------");//20170702
            int[] a = GetRandomArray(100000);
            watch.Restart();
            int countTwo = (SumFast.TwoSumCount(a));
            watch.Stop();
            Console.WriteLine(countTwo + "  " + watch.Elapsed);
            a = GetRandomArray(100000);
            //watch.Restart();
            //countTwo = (SumFast.ThreeSumCount(a));
            //watch.Stop();
            //Console.WriteLine(countTwo + "  " + watch.Elapsed);
            watch.Restart();
            countTwo = (SumFast.TwoSumCountPro(a));
            watch.Stop();
            Console.WriteLine(countTwo + "  " + watch.Elapsed);

            Console.WriteLine("----------------------算法分析练习------------------------");
            double[] dou = GetDoubleRandomArray(10000);
            var result = Exercise.SearchNearestValue(dou);
            Console.WriteLine("最接近的值为 " + result.Item1 + " 数组中的值是 " + dou[result.Item2] + " " + dou[result.Item3]);

            a = GetRandomArray(10);
            Array.Sort(a);
            int index = Exercise.FibonacciSearch(5, a);

            countTwo = Exercise.ThrowEggs(200);

            QuickFind_UF quickUF = new QuickFind_UF(10);//20170704
            quickUF.Union(1, 3);
            quickUF.Union(2, 3);
            bool ret = quickUF.Connected(1, 2); //true

            QuickUnion_UF quickUnion = new QuickUnion_UF(10);
            quickUnion.Union(2, 3);
            quickUnion.Union(2, 4);
            ret = quickUnion.Connected(3, 4); //true

            WeightedQuickUnion_UF weight = new WeightedQuickUnion_UF(10);
            weight.Union(2, 3);
            weight.Union(2, 4);
            ret = weight.Connected(3, 4); //true
            
            */
            #endregion

            int length = 1000000;

            //优先队列   用于插入元素和删除最大元素  20170708
            //var array = new Program().GetRandomIComparableArray(length);
            //var max = new MaxPQ<IComparable>(array).DelMax();

            Parallel.Invoke(
                () => Sort("Selection", length),
                () => Sort("Insertion", length),
                () => Sort("InsertionPro", length),
                () => Sort("Shell", length),
                () => Sort("Merge", length),
                () => Sort("MergeBU", length),
                () => Sort("Quick", length),
                () => Sort("Quick3Way", length),
                () => Sort("Heap", length));

            //Task.Factory.StartNew(() => Sort("Selection", length));
            //Task.Factory.StartNew(() => Sort("Insertion", length));
            //Task.Factory.StartNew(() => Sort("InsertionPro", length));
            //Task.Factory.StartNew(() => Sort("Shell", length));
            //Task.Factory.StartNew(() => Sort("Merge", length));
            //Task.Factory.StartNew(() => Sort("MergeBU", length));

            Console.ReadKey();
        }

        private static void Sort(string name, int length)
        {
            IComparable[] array;
            Stopwatch watch = new Stopwatch();
            Example sorter;
            switch (name)
            {
                case "Selection":
                    array = new Program().GetRandomIComparableArray(length);//20170705
                    sorter = new Selection();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("选择排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "Insertion":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Selection();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("插入排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "InsertionPro":
                    //array = new Program().GetRandomIComparableArray(length);
                    //watch.Start();
                    //new Insertion().SortPro(array);
                    //watch.Stop();
                    //Console.WriteLine("插入排序改进版法：" + watch.Elapsed);
                    break;
                case "Shell":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Shell();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("希尔排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "Merge":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Merge();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("归并（自顶向下）排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "MergeBU":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new MergeBU();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("归并（自底向上）排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "Quick":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Quick();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("快速排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "Quick3Way":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Quick3Way();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("快速排序法（三向切分）：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
                case "Heap":
                    array = new Program().GetRandomIComparableArray(length);
                    sorter = new Heap();
                    watch.Start();
                    sorter.Sort(array);
                    watch.Stop();
                    Console.WriteLine("堆排序法：" + watch.Elapsed + "  结果是否有序 " + sorter.IsSorted(array));
                    break;
            }
        }

        private static int[] GetRandomArray(int length)
        {
            int[] rnds = new int[length];
            Random md = new Random();
            for (int i = 0; i < length; i++)
                rnds[i] = md.Next();

            return rnds;
        }

        private IComparable[] GetRandomIComparableArray(int length)
        {
            IComparable[] rnds = new IComparable[length];
            //Random rd = new Random((int)(DateTime.Now.Ticks & 0xfffffffL) | (int)(DateTime.Now.Ticks >> 32));
            //for (int i = 0; i < length; i++)
            //    rnds[i] = rd.Next();

            Random rnd = new Random();
            byte[] keys = new byte[length];
            rnd.NextBytes(keys);
            for (int i = 0; i < length; i++)
                rnds[i] = i;

            IComparable[] result = new IComparable[length];
            Array.Sort(keys, rnds);
            Array.Copy(rnds, result, length);
            return result;
        }

        private static double[] GetDoubleRandomArray(int length)
        {
            double[] rnds = new double[length];
            Random md = new Random();
            for (int i = 0; i < length; i++)
                rnds[i] = md.NextDouble() * 10000;

            return rnds;
        }
    }
}
