using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 下压堆栈（链表实现）  by  zhangning   20170701
    /// </summary>
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> first; //栈顶（最近添加的元素）
        private int N;//元素数量

        public bool IsEmpty() { return first == null; }//或 N==0
        public int Size() { return N; }

        /// <summary>
        /// 向栈顶添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            Node<T> oldFirst = first;
            first = new Node<T>();
            first.Item = item;
            first.Next = oldFirst;
            N++;
        }

        /// <summary>
        /// 从栈顶删除元素
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T item = first.Item;
            first = first.Next;
            N--;
            return item;
        }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <param name="stack"></param>
        public static Stack<T> Copy(Stack<T> stack)
        {
            Stack<T> stackCopy = new Stack<T>();
            Stack<T> stackCopy1 = new Stack<T>();
            foreach (T item in stack)
                stackCopy1.Push(item);
            foreach (T item in stackCopy1)
                stackCopy.Push(item);

            return stackCopy;
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
