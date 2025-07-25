﻿using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Redis
{
    [Provider,Inject]
    public class RedisStringService: RedisBase
    {
        public RedisStringService(RedisManager redisManager) : base(redisManager)
        {
        }
        #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        public bool Set<T>(string key, T value)
        {
            //iClient.Db =2;
            return base.IClient.Set<T>(key, value);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set<T>(string key, T value, DateTime dt)
        {
            //iClient.Db = 2;
            return base.IClient.Set<T>(key, value, dt);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            //iClient.Db = 2;
            return base.IClient.Set<T>(key, value, sp);
        }
        /// <summary>
        /// 设置多个key/value  可以一次保存多个key value ---多个key value 不是分多次，是一个独立的命令；
        /// </summary>
        public void Set(Dictionary<string, string> dic)
        {
            //iClient.Db = 2;
            base.IClient.SetAll(dic);
        }

        #endregion

        #region 追加
        /// <summary>
        /// 在原有key的value值之后追加value,没有就新增一项
        /// </summary>
        public long Append(string key, string value)
        {
            return base.IClient.AppendTo(key, value);
        }
        #endregion

        #region 获取值
        /// <summary>
        /// 获取key的value值
        /// </summary>
        public string Get(string key)
        {
            return base.IClient.GetValue(key);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<string> Get(List<string> keys)
        {
            return base.IClient.GetValues(keys);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<T> Get<T>(List<string> keys)
        {
            return base.IClient.GetValues<T>(keys);
        }


        public T Get<T>(string key)
        {
            return base.IClient.Get<T>(key);
        }


        #endregion

        #region 获取旧值赋上新值
        /// <summary>
        /// 获取旧值赋上新值
        /// </summary>
        public string GetAndSetValue(string key, string value)
        {
            return base.IClient.GetAndSetValue(key, value);
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 获取值的长度
        /// </summary>
        public long GetLength(string key)
        {
            return base.IClient.GetStringCount(key);
        }
        /// <summary>
        /// 自增1，返回自增后的值   保存的是10   调用后，+1   返回11
        /// </summary>
        public long Incr(string key)
        {
            return base.IClient.IncrementValue(key);
        }
        /// <summary>
        /// 自增count，返回自增后的值   自定义自增的步长值
        /// </summary>
        public long IncrBy(string key, int count)
        {
            return base.IClient.IncrementValueBy(key, count);
        }
        /// <summary>
        /// 自减1，返回自减后的值，Redis操作是单线程操作；不会出现超卖的情况
        /// </summary>
        public long Decr(string key)
        {
            return base.IClient.DecrementValue(key);
        }
        /// <summary>
        /// 自减count ，返回自减后的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long DecrBy(string key, int count)
        {
            return base.IClient.DecrementValueBy(key, count);
        }

        /// <summary>
        /// 设置滑动过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public bool ExpireEntryIn(string key, TimeSpan timeSpan)
        {
            return IClient.ExpireEntryIn(key, timeSpan);
        }


        #endregion
    }
}
