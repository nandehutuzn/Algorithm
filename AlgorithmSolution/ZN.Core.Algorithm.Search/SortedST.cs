using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 有序符号表   by zhangning  20170710
    /// </summary>
    public abstract class SortedST<Key, Value> where Key : IComparable
    {
        public SortedST() { }

        /// <summary>
        /// 将键值对插入表中(若值为空则将键key从表中删除)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public abstract void Put(Key key, Value val);

        /// <summary>
        /// 获取键key对应的值  （若键key不存在则返回null）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract Value Get(Key key);

        /// <summary>
        /// 从表中删去键Key（及其对应的值）
        /// </summary>
        /// <param name="key"></param>
        public abstract void Delete(Key key);

        /// <summary>
        /// 键Key在表中是否有对应到值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(Key key)
        {
            return Get(key) != null;
        }

        /// <summary>
        /// 表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        /// <summary>
        /// 表中的键值对数量
        /// </summary>
        /// <returns></returns>
        public abstract int Size();

        /// <summary>
        /// 最小的键
        /// </summary>
        /// <returns></returns>
        public abstract Key Min();

        /// <summary>
        /// 最大的键
        /// </summary>
        /// <returns></returns>
        public abstract Key Max();

        /// <summary>
        /// 小于等于key的最大键  （向下取整）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract Key Floor(Key key);

        /// <summary>   
        /// 大于等于key的最小键   （向上取整）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract Key Ceiling(Key key);

        /// <summary>
        /// 小于键的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract int Rank(Key key);

        //综合  Rank   和 Select  方法，对于所有的0到size()-1的所有i都有 i==Rank(Select(i))
        //且所有的键都满足 key=Select(Rank(Key))

        /// <summary>
        /// 排名为k的键
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract Key Select(int k);

        /// <summary>
        /// 删除最小的键
        /// </summary>
        public virtual void DeleteMin()
        {
            Delete(Min());
        }

        /// <summary>
        /// 删除最大的键
        /// </summary>
        public virtual void DeleteMax()
        {
            Delete(Max());
        }

        /// <summary>
        /// [lo...hi]之间键的数量
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public int Size(Key lo, Key hi)
        {
            if (hi.CompareTo(lo) < 0)
                return 0;
            else if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// [lo...hi]之间键的所有键，已排序
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public abstract Key[] Keys(Key lo, Key hi);


        /// <summary>
        /// 表中的所有键的集合，已排序
        /// </summary>
        /// <returns></returns>
        public virtual Key[] Keys()
        {
            return Keys(Min(), Max());
        }
    }
}
