using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Autofac.Common
{
  public   class CacheMgr
    {
      private static   ICacheManager cacheManager = (CacheManager)CacheFactory.GetCacheManager();

       
      public static ICacheManager Container
      {
          get 
          {
              return cacheManager; 
          }
      }
    }
}
