using System;

namespace DMS.SharedKernel.Infrastructure.CacheStorage
{
    public interface ICacheStorage
    {
        void Remove(string key);
        void Store(string key, object data);
        void Store(string key, object data, DateTime expireTime);
        T Retrieve<T>(string storageKey);

        void RemoveRuntime(string key);
        void StoreRuntime(string key, object data);
        void StoreRuntime(string key, object data, DateTime expireTime);
        T RetrieveRuntime<T>(string storageKey);

    }
}
