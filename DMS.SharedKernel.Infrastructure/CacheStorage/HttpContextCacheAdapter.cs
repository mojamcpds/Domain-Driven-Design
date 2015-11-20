using System;
using System.Web;

namespace DMS.SharedKernel.Infrastructure.CacheStorage
{
    public class HttpContextCacheAdapter : ICacheStorage
    {
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
            
        }
        public void Store(string key, object data, DateTime expireTime)
        {
            HttpContext.Current.Cache.Insert(key, data, null, expireTime, TimeSpan.Zero);
        }

        public T Retrieve<T>(string key)
        {
            T itemStored = (T)HttpContext.Current.Cache.Get(key);
            if (itemStored == null)
                itemStored = default(T);

            return itemStored;
        }


        public void RemoveRuntime(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public void StoreRuntime(string key, object data)
        {
            HttpRuntime.Cache.Insert(key, data);

        }
        public void StoreRuntime(string key, object data, DateTime expireTime)
        {
            HttpRuntime.Cache.Insert(key, data, null, expireTime, TimeSpan.Zero);
        }

        public T RetrieveRuntime<T>(string key)
        {
            T itemStored = (T)HttpRuntime.Cache.Get(key);
            if (itemStored == null)
                itemStored = default(T);

            return itemStored;
        }

       
    }
}
