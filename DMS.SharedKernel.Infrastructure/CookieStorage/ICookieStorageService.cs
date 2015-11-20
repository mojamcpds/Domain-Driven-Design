using System;

namespace DMS.SharedKernel.Infrastructure.CookieStorage
{
    public interface ICookieStorageService
    {
        void SaveCookie(string key, string value, DateTime expires);
        string RetrieveCookie(string key);
    }
}
