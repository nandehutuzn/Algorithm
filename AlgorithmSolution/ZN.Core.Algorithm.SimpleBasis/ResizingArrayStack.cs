using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 下压栈（LIFO）----能够动态调整数组大小的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResizingArrayStack<T> : IEnumerable<T>
    {
        private T[] a = new T[1];
        private int N = 0;

        /// <summary>
        /// 是否为空栈
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() { return N == 0; }

        /// <summary>
        /// 栈的大小
        /// </summary>
        /// <returns></returns>
        public int Size() { return N; }

        private void Resize(int max)
        {//将栈移动到一个大小为max的新数组中
            T[] temp = new T[max];
            for (int i = 0; i < N; i++)
                temp[i] = a[i];

            a = temp;
        }

        /// <summary>
        /// 将元素添加到栈顶
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {   
            if (N == a.Length) Resize(2 * a.Length);
            a[N++] = item;
        }

        /// <summary>
        /// 从栈顶删除元素
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T item = a[--N];
            a[N] = default(T);
            if (N > 0 && N == a.Length / 4) Resize(a.Length / 2);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ReverseArrayIteator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ReverseArrayIteator(this);
        }

        /// <summary>
        /// 支持先进后出的迭代
        /// </summary>
        private class ReverseArrayIteator : IEnumerator<T>
        {
            private int i;
            private T[] a;

            public ReverseArrayIteator(ResizingArrayStack<T> owner)
            {
                i = owner.N;
                a = owner.a;
            }

            public T Current
            {
                get { return a[--i]; }
            }

            public void Dispose()
            {
                a = null;
            }

            public bool MoveNext()
            {
                return i > 0;
            }

            public void Reset()
            {
                a = new T[i];
            }

            object System.Collections.IEnumerator.Current
            {
                get { return a[--i]; ; }
            }
        }
    }
}

