using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

//using Memcached.ClientLibrary;
using BeIT.MemCached;

namespace Memcached
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Memcached.ClientLibrary
            /*
            //string[] servicelist = { "140.192.34.72:11211", "140.192.34.73:11211" };
            string[] servicelist = { "137.0.0.1:11211", "192.168.0.238:11211", "140.192.34.72:11211", "140.192.34.73:11211", "140.192.34.43:11211", "140.192.34.33:11211" };
            Console.WriteLine("\tservice count:{0}", servicelist.Length);
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servicelist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 6;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();

            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = true;
            var watch = Stopwatch.StartNew();
            Console.WriteLine("------------Test-------------");
            watch.Start();
            mc.Set("test", "my value");
            watch.Stop();
            Console.WriteLine("\tset time:{0}", watch.ElapsedMilliseconds);

            watch.Restart();
            if (mc.KeyExists("test"))
            {
                Console.WriteLine("Key:test is exists");
                Console.WriteLine("Key:test's value is:{0}", mc.Get("test").ToString());
            }
            else
            {
                Console.WriteLine("Key:test is not exists");
            }
            watch.Stop();
            Console.WriteLine("\tKeyExists time:{0}", watch.ElapsedMilliseconds);


            Console.ReadLine();

            watch.Restart();
            mc.Delete("test");
            watch.Stop();
            Console.WriteLine("\tDelete time:{0}", watch.ElapsedMilliseconds);

            if (mc.KeyExists("test"))
            {
                Console.WriteLine("Key:test is exists");
                Console.WriteLine("Key:test's value is:{0}", mc.Get("test").ToString());
            }
            else
            {
                Console.WriteLine("Key:test is not exists");
            }

            SockIOPool.GetInstance().Shutdown();
            */
            #endregion

            #region BeIT.MemCached
            /*
            MemcachedClient.Setup("TestCache", new string[] { "192.168.0.1" });
            MemcachedClient cache = MemcachedClient.GetInstance("TestCache");
            cache.SendReceiveTimeout = 5000;
            cache.MinPoolSize = 1;
            cache.MaxPoolSize = 5;
            cache.Set("jinjazz", "剪刀");
            object obj = cache.Get("jinjazz");
            Console.WriteLine(obj);
            */
            #endregion
        }
    }
}
