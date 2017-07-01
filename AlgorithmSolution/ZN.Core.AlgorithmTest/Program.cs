﻿using System;
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

            Console.ReadKey();
        }

        private static int[] GetRandomArray(int length)
        {
            int[] rnds = new int[length];
            Random md = new Random();
            for (int i = 0; i < length; i++)
                rnds[i] = md.Next();

            return rnds;
        }
    }
}