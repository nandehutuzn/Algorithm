using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Search
{
    /// <summary>
    /// 泛型符号表  by zhangning  20170710
    /// </summary>
    public abstract class ST<Key, Value>
    {
        public ST()
        { }

        /// <summary>
        /// 将键值对存入表中（若值为空则将键key从表中删除）
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
        public virtual void Delete(Key key)
        {
            Put(key, default(Value));
        }

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
        /// 表中的所有键的集合
        /// </summary>
        /// <returns></returns>
        public abstract Key[] Keys();
    }
}
