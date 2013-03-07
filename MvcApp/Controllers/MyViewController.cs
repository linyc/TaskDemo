using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace MvcApp.Controllers
{
    public class MyViewController : Controller
    {
        public ActionResult MyViewPage()
        {
            return View();
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public string GetMsg(Customer cus)
        {
            return string.Format("Name:{0}, Sex:{1}, Age:{2}", cus.Name, cus.Sex, cus.Age);
        }
        //------------------
        public string GetBase64(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }
        public string GetMd5(string input)
        {
            byte[] bs = Encoding.UTF8.GetBytes(input);
            byte[] md5 = new MD5CryptoServiceProvider().ComputeHash(bs);
            return BitConverter.ToString(md5);
        }
        public string GetSha1(string input)
        {
            byte[] bs = Encoding.UTF8.GetBytes(input);
            byte[] sha1 = new SHA1CryptoServiceProvider().ComputeHash(bs);
            return BitConverter.ToString(sha1);
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
    }
}
