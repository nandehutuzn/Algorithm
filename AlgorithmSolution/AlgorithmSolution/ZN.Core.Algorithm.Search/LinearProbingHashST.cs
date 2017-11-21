using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 基于线性探测的散列表  by zhangning  20170712
    /// </summary>
    public class LinearProbingHashST<Key, Value> : ST<Key, Value>
    {
        private int N;  //散列表中键值对数量
        private int M = 16; //线性探测表的大小
        private Key[] keys;  //键
        private Value[] values;  //值

        public LinearProbingHashST()
        {
            keys = new Key[M];
            values = new Value[M];
        }

        public LinearProbingHashST(int m)
        {
            keys = new Key[m];
            values = new Value[m];
            M = m;
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        /// <summary>
        /// 重新设置线性探测表大小
        /// </summary>
        /// <param name="cap"></param>
        private void Resize(int cap)
        {
            LinearProbingHashST<Key, Value> t;
            t = new LinearProbingHashST<Key, Value>(cap);
            for (int i = 0; i < M; i++)
            {
                if (keys[i] != null)
                    t.Put(keys[i], values[i]);
            }

            keys = t.keys;
            values = t.values;
            M = t.M;
        }

        public override void Put(Key key, Value val)
        {
            if (N >= M / 2) Resize(2 * M);

            int i;
            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = val;
                    return;
                }
            }
            keys[i] = key;
            values[i] = val;
            N++;
        }

        public override Value Get(Key key)
        {
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                    return values[i];
            }
            return default(Value);
        }

        public override void Delete(Key key)
        {
            if (!Contains(key)) return;

            int i = Hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % M;

            keys[i] = default(Key);
            values[i] = default(Value);

            while (keys[i] != null)
            {
                Key keyToRedo = keys[i];
                Value valToRedo = values[i];
                keys[i] = default(Key);
                values[i] = default(Value);
                N--;
                Put(keyToRedo, valToRedo);
                i = (i + 1) % M;
            }
            N--;
            if (N > 0 && N <= M / 8)
                Resize(M / 2);
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
