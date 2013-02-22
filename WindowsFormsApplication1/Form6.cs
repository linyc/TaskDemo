using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            this.webBrowser1.ObjectForScripting = this;
            this.webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\menu";
            string s = "<head><link href=\"" + path + "\\styles\\styles.css\"  type=\"text/css\" rel=\"stylesheet\"/><link href=\"" + path + "\\styles\\cn100_global.css\"  type=\"text/css\" rel=\"stylesheet\"/></head>"
                + "<body><div class=\"menu_box\">  <h1 class=\"menu_title\">梦芭莎的类目列表</h1>  <a href=\"#\" class=\"menu_close\" onclick=\"javascript:window.external.closeme();\">关闭</a>  <ul class=\"menu_list\">    <li><a href=\"#\">女装</a></li>    <li><a href=\"#\">男装</a></li>    <li><a href=\"#\">数码</a></li><li><a href=\"#\">女鞋</a></li></ul></div></body>";
            //s = string.Format(s, path);
            this.webBrowser1.DocumentText = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void closeme()
        {
            this.webBrowser1.Visible = false;
        }
    }
}
