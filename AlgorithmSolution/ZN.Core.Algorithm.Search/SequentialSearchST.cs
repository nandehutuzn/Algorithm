using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 顺序查找  （基于无序链表）
    /// </summary>
    public class SequentialSearchST<Key, Value> : ST<Key, Value>
    {
     
        private class Node
        {
            public Node(Key key, Value val, Node next)
            {
                this.Key = key;
                this.Val = val;
                this.Next = next;
            }

            public Key Key { get; set; }
            public Value Val { get; set; }
            public Node Next { get; set; }
        }

        private Node first;  //链表首节点
        private int N; //数量

        /// <summary>
        /// 查找给定的键，找到则更新其值，否则在表中新建节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public override void Put(Key key, Value val)
        {
            Node lastNode = null;
            for (Node x = first; x != null; x = x.Next)
            {
                if (x.Key.Equals(key))//命中，更新
                {
                    if (val != null)
                    {
                        x.Val = val;
                        return;
                    }
                    else //val为null，删除该节点
                    {
                        N--;
                        lastNode.Next = x.Next;
                        return;
                    }
                }
                lastNode = x;
            }
            N++;
            first = new Node(key, val, first);//未命中，新建节点

        }

        /// <summary>
        /// 查找给定的键，返回相关联的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override Value Get(Key key)
        {
            for (Node x = first; x != null; x = x.Next)
            {
                if (key.Equals(x.Key))//命中
                    return x.Val;
            }

            return default(Value); //未命中
        }

        public override int Size()
        {
            return N;
        }

        public override Key[] Keys()
        {
            Key[] keys = new Key[N];
            int i=0;
            for (Node x = first; x != null; x = x.Next)
                keys[i++] = x.Key;

            return keys;
        }
    }
}
