using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Collections.Specialized;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArraySegmentTest.ArrSegTest();
            
            //MyMongoDb mdb = new MyMongoDb();
            //Customer cus = new Customer
            //{
            //    CustomerID = Guid.NewGuid().ToString(),
            //    CustomerName = "yctest:"+DateTime.Now.GetHashCode(),
            //    Address = "ycaddress",
            //    ContactName = "yccontactname",
            //    PostalCode = "ycpostalcode",
            //    Tel = "电话号码"
            //};
            //mdb.Insert(cus);
            //mdb.Delete("yctel");

            //List<Customer> cusList=mdb.GetList(null);
            //foreach (var item in cusList)
            //{
            //    Console.WriteLine("{0}{1}",item.ToString(),Environment.NewLine);
            //}

            //do
            //{
            //    MyOptions myopt = CacheTest.MyOption;
            //    Console.WriteLine("name:" + myopt.name + "sex:" + myopt.sex);
            //    System.Threading.Thread.Sleep(3000);
            //} while (true);

            string s = @"<img src='http://img03.cn100.com/01220130117001e72411922e684ed0b9869c9e7771ccbe.jpg=88X88.jpg' onclick='window.location.href='\x68\x74\x74\x70\x3A\x2F\x2F\x77\x77\x77\x2E\x71\x71\x2E\x63\x6F\x6D\x2F ';'/>";
            string newS = HttpUtility.HtmlAttributeEncode(s);
            string newS2 = HttpUtility.HtmlEncode(s);
            string newS3 = HttpUtility.JavaScriptStringEncode(s);
            Console.WriteLine("{1}{0}{0}{2}{0}{0}{3}{0}{0}{4}", Environment.NewLine, s, newS, newS2, newS3);

            NameValueCollection nvCol =HttpUtility.ParseQueryString("http://img03.cn100.com/71ccbe.jpg?a=1&b=3&aa=ddd");
            for (int i = 0; i < nvCol.Count; i++)
            {
                Console.WriteLine(nvCol[i]);
            }

            Console.ReadLine();
        }
    }

    [assembly: CLSCompliant(true)]
    internal class K
    {
        public sbyte __MyProperty { get; set; }
        public string name { get; set; }
        void Name() { }
    }
}
