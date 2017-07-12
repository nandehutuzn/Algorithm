using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 基于拉链法的散列表   by  zhangning  20170712
    /// </summary>
    public class SeparateChainingHashST<Key, Value> : ST<Key, Value>
    {
        private int N;//键值对总数
        private int M;//散列表的大小
        private SequentialSearchST<Key, Value>[] st; //存放链表对象的数组

        public SeparateChainingHashST()
           : this(997)
        { 
        }

        public SeparateChainingHashST(int m)
        {
            this.M = m;
            st = new SequentialSearchST<Key, Value>[M];
            for (int i = 0; i < M; i++)
                st[i] = new SequentialSearchST<Key, Value>();
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public override void Put(Key key, Value val)
        {
            st[Hash(key)].Put(key, val);
        }

        public override Value Get(Key key)
        {
            return st[Hash(key)].Get(key);
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }

        public override Key[] Keys()
        {
            throw new NotImplementedException();
        }
    }
}
