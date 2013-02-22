using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class ArraySegmentTest
    {
        public static void ArrSegTest()
        {
            List<User> uList = new List<User>();
            for (int i = 0; i < 50; i++)
            {
                uList.Add(new User { uindex = i, uname = "n" + i });
            }
            ArraySegment<User> arrUList = new ArraySegment<User>(uList.ToArray(), 20, 10);
            for (int j = arrUList.Offset; j < arrUList.Offset+arrUList.Count; j++)
            {
                Console.WriteLine(arrUList.Array[j].ToString());
            }
        }
    }
    class User
    {
        public int uindex { get; set; }
        public string uname { get; set; }

        public override string ToString()
        {
            return string.Format("name:{0}, ind:{1}", uname, uindex);
        }
    }

}