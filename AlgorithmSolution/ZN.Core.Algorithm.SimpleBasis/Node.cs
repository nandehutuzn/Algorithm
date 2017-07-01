using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.SimpleBasis
{
    /// <summary>
    /// 链表基本结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
    }
}
