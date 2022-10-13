using System;
using System.Collections.Generic;
using System.Text;

namespace CRB.DA.CacheModel
{
    public interface ICacheModel
    {
        void Add<T>(string key, T item);
        bool Get<T>(string key, out T item);
    }
}
