using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string lenstr = this.textBox1.Text;
            //this.textBox2.Text = Encoding.GetEncoding(this.textBox3.Text).GetByteCount(lenstr).ToString();

            //string reg=@"/(?<name>(\w[\./\w]*)?(?=Ajax)\w+)[/\.](?<method>\w+)\.[a-zA-Z]+";
            //Match m = Regex.Match(this.textBox1.Text, reg);
            //string format = "name:{0}\tmethod:{1}";
            //this.textBox2.Text = string.Format(format, m.Groups["name"].Value.Replace("/", "."), m.Groups["method"].Value);

            //this.textBox2.Text = TestATagWithOutlink(textBox1.Text).ToString();


            //string pwd = "cnmanage@163.com";
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(ms, pwd);
            //    string pwdSer = Convert.ToBase64String(ms.ToArray());
            //    Console.WriteLine(pwdSer);
            //}

            StringBuilder sbInput = new StringBuilder(this.textBox1.Text);
            //Regex reg = new Regex(@"<[^<>]*[\s]*[^<>]*a[\s]+[.]*href[^<>]*[\s]*[^<>]*=[\s]*[""']?[^(http://)(cn100.com)]+[""']?[.]*>", RegexOptions.IgnoreCase);
            //Regex reg = new Regex(@"<\s*a[ ]+.*href[ ]*=[""']?.+[""']?[^<>]*>.*</a>");
            Regex reg = new Regex(@"(http(s)?://)?((/)?[\w-.]+/)*[\w-\.!%]+\.(jpg|jpeg|png|gif|bmp)");
            MatchCollection matchList = reg.Matches(this.textBox1.Text);
            int i = 0;
            foreach (Match item in matchList)
            {
                this.textBox2.Text += item.Value + Environment.NewLine + Environment.NewLine;
                i++;
            }
            this.Text = i.ToString();
        }

        public static StringBuilder TestATagWithOutlink(string inputStr)
        {
            Regex reg = new Regex(@"(href((\s)*)=([^>]*))(http|https|ftp):(\/\/|\\\\)((\w)(.?)(?!cn100)){1,}(net|com|cn|org|cc|tv|[0-9]{1,})([^>]*)", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);

            StringBuilder sbInputStr = new StringBuilder();
            sbInputStr.Append(reg.Replace(inputStr, "href='#'"));
            return sbInputStr;
        }
    }
}
