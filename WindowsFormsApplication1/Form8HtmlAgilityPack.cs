using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using HtmlAgilityPack;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form8HtmlAgilityPack : Form
    {
        public Form8HtmlAgilityPack()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = this.textBox1.Text;
            //HtmlWeb hweb = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc = hweb.Load(@"http://www.cnblogs.com/");
            //HtmlNode docnode = doc.DocumentNode;
            //foreach(var i in docnode.SelectNodes("//@on*"))
            //{
            //    this.textBox2.Text += "\r\n" + i.OuterHtml;
            //}

            //HtmlWeb hweb = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument hdoc = hweb.Load(@"http://www.cnblogs.com/");
            ////StringBuilder sb=new StringBuilder();
            ////StringWriter sw = new StringWriter(sb);
            ////XmlTextWriter xmltw = new XmlTextWriter(sw);
            ////hweb.LoadHtmlAsXml(@"http://www.cnblogs.com/",xmltw);
            ////this.textBox2.Text = sb.ToString();

            ////HtmlNodeCollection hnodecol = hdoc.DocumentNode.SelectNodes(@"//a[@class='titlelnk']");
            //string sformat = "title:{1}{0}author:{2}{0}time:{3}{0}{0}";
            ////foreach (var item in hnodecol)
            ////{
            ////    this.textBox1.Text += string.Format(sformat, item.InnerHtml);
            ////}

            //HtmlNodeCollection hnodecol = hdoc.DocumentNode.SelectNodes(@"//div[@class='post_item_body']");
            //for (int i = 0; i < hnodecol.Count; i++)
            //{
            //    string s1 = hnodecol[i].SelectSingleNode("//a[@class='titlelnk']").InnerHtml;
            //    string s2 = hnodecol[i].SelectSingleNode("//a[@class='lightblue']").InnerHtml;
            //    string s3 = hnodecol[i].SelectSingleNode("//a[@class='lightblue']").NextSibling.InnerText.Replace("\r\n", "").Trim();
            //    this.textBox1.Text += string.Format(sformat, Environment.NewLine, s1, s2, s3);
            //}

            ////HtmlNodeCollection hnodecol = hdoc.DocumentNode.SelectNodes("a");
            ////foreach (var item in hnodecol)
            ////{
            ////    this.textBox1.Text = item.InnerText;
            ////}

            //string s = "<img src=\"http://img03.cn100.com/01220130117001e72411922e684ed0b9869c9e7771ccbe.jpg=88X88.jpg\" onclick=\"window.location.href='\x68\x74\x74\x70\x3A\x2F\x2F\x77\x77\x77\x2E\x71\x71\x2E\x63\x6F\x6D\x2F ';\"/>";
            //this.textBox2.Text= Weirhp.NHtmlFilter.htmlSpecialChars(s);

            string s = this.textBox1.Text;
            string patten = @"(onabort|onblur|onchange|onclick|ondblclick|onerror|onfocus|onkeydown|onkeypress|onKeyUp|onload|onmousedown|onmousemove|onmouseout|onmouseover|onmouseup|onreset|onresize|onselect|onsubmit|onunload)[\s]*=";
            this.textBox2.Text = Regex.Replace(s, patten, "ut=",RegexOptions.IgnoreCase);
        }
    }
}
