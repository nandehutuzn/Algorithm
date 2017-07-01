using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 背包（链表实现）  by zhangning  20170701
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Bag<T> : IEnumerable<T>
    {
        private Node<T> first;
        private int N;

        public void Add(T item)
        {
            Node<T> oldFirst = first;
            first = new Node<T>();
            first.Item = item;
            first.Next = oldFirst;
            N++;
        }

        public bool IsEmpty() { return N == 0; }
        public int Size() { return N; }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator<T>(first);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ListIterator<T>(first);
        }
    }
}
