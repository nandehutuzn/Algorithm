using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 二分查找（基于有序数组）  by zhangning  20170711
    /// </summary>
    public class BinarySearchST<Key, Value> : SortedST<Key, Value> where Key : IComparable
    {
        private Key[] keys;
        private Value[] vals;
        private int N;

        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }

        public override void Put(Key key, Value val)
        {
            int i = Rank(key);//找出小于该键的数量，即该键应该所处的索引
            if (i < N && keys[i].CompareTo(key) == 0)
            {
                vals[i] = val;
                return;
            }

            for (int j = N; j > i; j--)  //大于该键的所有均往后移一位
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }

            keys[i] = key;
            vals[i] = val;
            N++;
        }

        public override Value Get(Key key)
        {
            if (IsEmpty()) return default(Value);

            int i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0) return vals[i];
            else return default(Value);
        }

        public override void Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            return N;
        }

        public override Key Min()
        {
            return keys[0];
        }

        public override Key Max()
        {
            return keys[N - 1];
        }

        public override Key Floor(Key key)
        {
            throw new NotImplementedException();
        }

        public override Key Ceiling(Key key)
        {
            int i = Rank(key);
            return keys[i];
        }

        public override int Rank(Key key)
        {
            int lo = 0, hi = N - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }

            return lo;
        }

        public override Key Select(int k)
        {
            return keys[k];
        }

        public override Key[] Keys(Key lo, Key hi)
        {
            int i = Rank(lo);
            int j = Rank(hi);
            int index = 0;
            int count = i + (j - i) / 2;
            if (keys.Contains(hi))
            {
                count = i + (j - i) / 2;
            }
            else count--;
            Key[] k = new Key[count];
            for (; i < j; i++)
                k[index++] = keys[i];

            if (keys.Contains(hi))
            {
                k[count - 1] = keys[j];
            }


            return k;
        }
    }
}
