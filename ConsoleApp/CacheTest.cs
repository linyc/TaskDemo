using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Reflection;
using System.IO;

namespace ConsoleApp
{
    /// <summary>
    /// 缓存依赖
    /// </summary>
    class CacheTest
    {
        public static MyOptions MyOption
        {
            get
            {
                MyOptions cacheOpt = HttpRuntime.Cache["opt"] as MyOptions;
                if (cacheOpt == null)
                {
                    string file=System.Windows.Forms.Application.StartupPath + "\\a.txt";
                    using (StreamReader sr = new StreamReader(File.OpenRead(file)))
                    {
                        cacheOpt = new MyOptions { name = sr.ReadLine(), sex = sr.ReadLine() };
                        CacheDependency dep = new CacheDependency(file.Replace("a.txt","b.txt"));
                        HttpRuntime.Cache.Insert("opt", cacheOpt, dep, DateTime.MaxValue,  TimeSpan.Zero,new CacheItemUpdateCallback(callback));
                        //HttpRuntime.Cache.Add(
                    }
                }

                return cacheOpt;
            }
        }

        static void callback(string key, CacheItemUpdateReason reason, out object expensiveObject, out CacheDependency dependency
            , out DateTime absoluteExpiration, out TimeSpan slidingExpiration)
        {
            expensiveObject = default(object);
            dependency = default(CacheDependency);
            absoluteExpiration = default(DateTime);
            slidingExpiration = default(TimeSpan);

            Console.WriteLine("key:{0},reason:{1},expensiveObject:{2},dependency:{3},absoluteExpiration:{4},slidingExpiration:{5}"
                , key, reason, expensiveObject, dependency, absoluteExpiration, slidingExpiration);

        }
    }

    class MyOptions
    {
        public string name { get; set; }
        public string sex { get; set; }
    }
}
