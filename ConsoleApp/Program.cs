using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    { 
        static void Main(string[] args)
        {
            #region ArraySegmentTest
            //ArraySegmentTest.ArrSegTest();
            #endregion

            #region MyMongoDb
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
            #endregion

            #region CacheTest
            //do
            //{
            //    MyOptions myopt = CacheTest.MyOption;
            //    Console.WriteLine("name:" + myopt.name + "sex:" + myopt.sex);
            //    System.Threading.Thread.Sleep(3000);
            //} while (true);
            #endregion

            #region ColorFormat
            //Color col = Color.FromName(@"#afafaf");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(System.Drawing.ColorTranslator.FromHtml("#afafaf"));
            //Console.Read();
            #endregion

            #region LinqTest
            //LinqTest lt = new LinqTest();
            //lt.get(0);
            #endregion 

            #region EnumTest
            EnumTest et = new EnumTest();
            et.myenum = MyEnum.b;
            Console.WriteLine(Convert.ToInt16(et.myenum));
            Console.Read();
            #endregion


            #region ClassPropertiesTest
            //IClassPropertiesTest cpt2 = new ClassPropertiesTest2();
            //cpt2.Count = 2;
            //Console.WriteLine(cpt2.Count);
            //Console.Read();
            //ClassPropertiesTest cpt = cpt2 as ClassPropertiesTest;
            //Console.WriteLine(cpt.sub.A);
            #endregion


            //string s = "http://tu.taobaocdn.com/s1/453271987/2011年秋冬牛仔/10595/10595主图";
            //Console.WriteLine(Path.GetExtension(s));
            //Console.Read();

            //string s = @"<img src='http://img03.cn100.com/01220130117001e72411922e684ed0b9869c9e7771ccbe.jpg=88X88.jpg' onclick='window.location.href='\x68\x74\x74\x70\x3A\x2F\x2F\x77\x77\x77\x2E\x71\x71\x2E\x63\x6F\x6D\x2F ';'/>";
            //string newS = HttpUtility.HtmlAttributeEncode(s);
            //string newS2 = HttpUtility.HtmlEncode(s);
            //string newS3 = HttpUtility.JavaScriptStringEncode(s);
            //Console.WriteLine("{1}{0}{0}{2}{0}{0}{3}{0}{0}{4}", Environment.NewLine, s, newS, newS2, newS3);

            //NameValueCollection nvCol = HttpUtility.ParseQueryString("http://img03.cn100.com/71ccbe.jpg?a=1&b=3&aa=ddd");
            //for (int i = 0; i < nvCol.Count; i++)
            //{
            //    Console.WriteLine(nvCol[i]);
            //}
            AttributeTest.k();


            Person p = new Person();
            p.UName = "ormtest";
            p.USex = "man";
            p.UAge = 12;

            PropertyInfo[] proInfos = p.GetType().GetProperties();
            foreach (PropertyInfo item in proInfos)
            {
                object[] objAttr = item.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (objAttr != null)
                    Console.WriteLine(string.Format("属性名：{0}\t对应数据库字段：{1}\t数据库类型：{2}"
                                , item.Name, (objAttr[0] as DataFieldAttribute).FieldName, (objAttr[0] as DataFieldAttribute).FieldType));
                Console.WriteLine(item.GetValue(p, null).ToString());
                Console.WriteLine(objAttr[0].GetType().Name);
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
