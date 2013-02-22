using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

            do
            {
                MyOptions myopt = CacheTest.MyOption;
                Console.WriteLine("name:" + myopt.name + "sex:" + myopt.sex);
                System.Threading.Thread.Sleep(3000);
            } while (true);

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
