using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ZN.Core.Algorithm.SimpleBasis;

namespace ZN.Core.AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadKey();
        }

        private static int[] GetRandomArray(int length)
        {
            int[] rnds = new int[length];
            Random md = new Random();
            for (int i = 0; i < length; i++)
                rnds[i] = md.Next(20);

            return rnds;
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
