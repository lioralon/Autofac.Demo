using Autofac.Interface;
using Autofac.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;

namespace Autofac.Impl
{
    public class Shouter : IShout
    {
        public string Shout(string name)
        {
            CacheMgr.Container.Add(name, name, CacheItemPriority.Normal, null, new AbsoluteTime(TimeSpan.FromSeconds(6)));
            return string.Format("{0} - meow,meow", name);

        }
    }
}