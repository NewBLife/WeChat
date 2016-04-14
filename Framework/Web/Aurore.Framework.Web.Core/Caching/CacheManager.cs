using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using Aurore.Framework.Core.Caching;

namespace Aurore.Framework.Web.Core.Caching
{

	public class CacheManager : ICacheManager
	{
        System.Web.Caching.Cache Cache = HttpRuntime.Cache;

        public void Set(string key, object data)
        {
            Cache.Insert(key, data);
        }
        public void Set(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache.Insert(key, data, null,absoluteExpiration, slidingExpiration);
        }

		public object Get(string Key)
		{
			return Cache[Key];
		}

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsSet(string key)
        {
            return Cache[key] != null;
        }

        public void Remove(string Key)
		{
			if (Cache[Key] != null) {
				Cache.Remove(Key);
			}
		}

		public void RemoveByPattern(string pattern)
		{
			IDictionaryEnumerator enumerator = Cache.GetEnumerator();
			Regex rgx = new Regex(pattern, (RegexOptions.Singleline | (RegexOptions.Compiled | RegexOptions.IgnoreCase)));
			while (enumerator.MoveNext()) {
				if (rgx.IsMatch(enumerator.Key.ToString())) {
					Cache.Remove(enumerator.Key.ToString());
				}
			}
		}

        public void Clear()
        {
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Cache.Remove(enumerator.Key.ToString());
            }
        }

	}

}