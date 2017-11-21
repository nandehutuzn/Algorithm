using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 先进先出队列（链表实现）   by zhagnning  20170701
    /// </summary>
    public class Queue<T> : IEnumerable<T>
    {

        private Node<T> first;  //指向最早添加的节点的链接
        private Node<T> last;  //指向最近添加的节点的链接
        private int N;  //队列中元素的数量

        public bool IsEmpty() { return first == null; }

        public int Size() { return N; }

        /// <summary>
        /// 向表尾添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            Node<T> oldLast = last;
            last = new Node<T>();
            last.Item = item;
            last.Next = null;
            if (IsEmpty()) first = last;
            else oldLast.Next = last;
            N++;
        }

        /// <summary>
        /// 从表头删除元素
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            T item = first.Item;
            first = first.Next;
            if (IsEmpty()) last = null;
            N--;
            return item;
        }

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
