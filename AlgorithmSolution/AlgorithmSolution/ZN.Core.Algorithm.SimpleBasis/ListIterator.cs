using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    class ListIterator<T> : IEnumerator<T>
    {
        private Node<T> curent;

        public ListIterator(Node<T> node)
        {
            curent = node;
        }

        public T Current
        {
            get
            {
                T item = curent.Item;
                curent = curent.Next;
                return item;
            }
        }

        public void Dispose()
        {
            curent = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                T item = curent.Item;
                curent = curent.Next;
                return item;
            }
        }

        public bool MoveNext()
        {
            return curent != null;
        }

        public void Reset()
        {
            curent.Next = null;
            curent = null;
        }
    }
}
