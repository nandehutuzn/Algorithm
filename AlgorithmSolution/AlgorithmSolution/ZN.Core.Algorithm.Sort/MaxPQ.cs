using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 优先队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxPQ<T> where T : IComparable
    {
        private T[] pq;  //基于堆的完全按二叉树
        private int N;  //存储于 pq[1...N]中, pq[0]没有使用

        public MaxPQ(int maxN)
        {
            pq = new T[maxN + 1];
        }

        public MaxPQ(T[] a)
        {
            pq = new T[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
                Insert(a[i]);
        }

        public void Insert(T v) 
        {
            pq[++N] = v;
            Swim(N);
        }

        public T Max()
        {
            return pq[1];
        }

        public T DelMax()
        {
            T max = pq[1]; //从根节点获得最大元素
            Exch(1, N--); //将其和最后一个节点交换
            pq[N + 1] = default(T);  //防止对象游离
            Sink(1); //恢复堆的有序性
            return max;
        }

        public bool IsEmpty() { return N == 0; }

        public int Size() { return N; }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void Exch(int i, int j)
        {
            T t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }

        /// <summary>
        /// 由下至上的堆有序化（上浮） 
        /// 父节点必须比子节点大  k节点父节点为k/2
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }

        /// <summary>
        /// 由上至下的堆有序化（下沉）
        /// 某个节点比两个子节点或是其中之一更小了而被打破了，那么我们可以通过将它和它的两个子节点中较大者
        /// 交换来恢复堆
        /// </summary>
        /// <param name="k"></param>
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int k = N / 2; k >= 1; k--)
            { 
            
            }
        }
    }
}
