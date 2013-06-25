using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsoleApp
{
    class RandomPwdTest
    {
        public static string generatePwd()
        {
            string pwdBaseStr = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //密码长度
            int pwdLen = 8;

            StringBuilder pwd = new StringBuilder(pwdLen);

            Random rnd = new Random(DateTime.Now.GetHashCode());

            //重新生成8位数的密码
            for (int i = 0; i < pwdLen; i++)
            {
                char c = pwdBaseStr[rnd.Next(0, pwdBaseStr.Length - 1)];
                pwd.Append(c);
            }

            return pwd.ToString();
        }

        public static void k()
        {
            TreeView tv = new TreeView();
            TreeNode tn = new TreeNode("1");
            tn.Name = "1";

            TreeNode tn2 = new TreeNode("2");
            tn2.Name = "2";

            TreeNode tn3 = new TreeNode("3");
            tn3.Name = "3";

            tn2.Nodes.Add(tn3);
            tn.Nodes.Add(tn2);
            tv.Nodes.Add(tn);

            Console.WriteLine(tn3.FirstNode.Name);
        }
    }
}
