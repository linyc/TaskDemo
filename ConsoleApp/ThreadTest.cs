
#define DEBUG


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;


namespace ConsoleApp
{
    public class ThreadTest
    {
        private static readonly object obj = new object();

        public void CreateThread(Dictionary<int, object> dic)
        {
            Thread th = null;

            for (int i = 0; i < 15;)
            {
                th = new Thread(new ThreadStart(delegate()
                {
                    AddData(dic,i);

                }));
                th.Name = i.ToString();
                th.Start();
                i++;
            }
        }

        [Conditional("DEBUG")]
        private void AddData(Dictionary<int, object> dic, int i)
        {
            lock (obj)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, i);
                    Console.WriteLine("{1} Add: {0} , i: {2} , thName: {3}", dic[i], DateTime.Now.Millisecond,i, Thread.CurrentThread.Name);
                }
                else
                {
                    //Console.WriteLine("{1} Set: {0}", i, DateTime.Now.Millisecond);
                    //dic[i] = (i ).ToString();
                }
            }
        }
    }
}
