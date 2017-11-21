using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 基于二叉查找树的符号表
    /// </summary>
    public class BST<Key, Value> : SortedST<Key, Value> where Key : IComparable
    {
        private class Node
        {
            public Key Key { get; set; }

            public Value Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            /// <summary>
            /// 以该节点为根的子树中节点总数
            /// </summary>
            public int N { get; set; }

            public Node(Key key, Value val, int N)
            {
                this.Key = key;
                this.Value = val;
                this.N = N;
            }
        }

        private Node root; //二叉查找树的根节点

        private int Size(Node x)
        {
            if (x == null) return 0;
            else return x.N;
        }


        /// <summary>
        /// 查找key，找到则更新它的值，否则为它创建一个新的节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public override void Put(Key key, Value val)
        {
            root = Put(root, key, val);
        }

        /// <summary>
        /// 如果key存在于以x为根节点的子树中则更新它的值
        /// 否则将以key和val为键值对的新节点插入到该子树中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private Node Put(Node x, Key key, Value val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.Key);

            if (cmp < 0) x.Left = Put(x.Left, key, val);
            else if (cmp > 0) x.Right = Put(x.Right, key, val);
            else x.Value = val;

            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override Value Get(Key key)
        {
            return Get(root, key);
        }

        /// <summary>
        /// x为根节点的子树中查找并返回key所对应的值 ,
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);// 如果找不到则返回null

            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Get(x.Left, key);
            else if (cmp > 0) return Get(x.Right, key);
            else return x.Value;
        }

        public override void Delete(Key key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);

            if (cmp < 0) x.Left = Delete(x.Left, key);
            else if (cmp > 0) x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null) return x.Left;
                if (x.Left == null) return x.Right;
                Node t = x;  //二叉查找树特性：右边结点都比左边结点大
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override int Size()
        {
            return Size(root);
        }

        public override Key Min()
        {
            return Min(root).Key;
        }

        private Node Min(Node x)
        {
            if (x.Left == null) return x;
            return Min(x.Left);
        }

        public override Key Max()
        {
            return Max(root).Key;
        }

        private Node Max(Node x)
        {
            if (x.Right == null) return x;
            return Max(x.Right);
        }

        public override Key Floor(Key key)
        {
            Node x = Floor(root, key);
            if (x == null) return default(Key);
            return x.Key;
        }

        private Node Floor(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);

            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.Left, key);
            Node t = Floor(x.Right, key);
            if (t != null) return t;
            else return x;
        }

        public override Key Ceiling(Key key)
        {
            Node x = Ceiling(root, key);
            if (x == null) return default(Key);
            return x.Key;
        }

        private Node Ceiling(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);

            if (cmp == 0) return x;
            if (cmp > 0) return Floor(x.Right, key);
            Node t = Floor(x.Left, key);
            if (t != null) return t;
            else return x;
        }

        public override int Rank(Key key)
        {
            return Rank(key, root);
        }

        /// <summary>
        /// 返回以x为根节点的子树中小于x.key的键的数量
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private int Rank(Key key, Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Rank(key, x.Left);
            else if (cmp > 0) return 1 + Size(x.Left) + Rank(key, x.Right);
            else return Size(x.Left);
        }

        public override Key Select(int k)
        {
            return Select(root, k).Key;
        }

        /// <summary>
        /// 返回排名为k的结点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private Node Select(Node x, int k)
        {
            if (x == null) return null;

            int t = Size(x.Left);
            if (t > k) return Select(x.Left, k);
            else if (t < k) return Select(x.Right, k - t - 1);
            else return x;
        }

        public override void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null) return x.Right;
            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override void DeleteMax()
        {
            root = DeleteMax(root);
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null) return x.Left;
            x.Right = DeleteMin(x.Right);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override Key[] Keys()
        {
            return Keys(Min(), Max());
        }

        public override Key[] Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue.ToArray();
        }

        private void Keys(Node x, Queue<Key> array, Key lo, Key hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.Key);
            int cmphi = hi.CompareTo(x.Key);

            if (cmplo < 0) Keys(x.Left, array, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) array.Enqueue(x.Key);
            if (cmphi > 0) Keys(x.Right, array, lo, hi);
            
        }
    }
}
