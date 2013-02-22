using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sp = Path.GetFileName(Application.StartupPath);
            Console.WriteLine(sp);
            Console.Read();
            return;


            string s = "12345678901";
            s = s.Length > 10 ? s.Substring(0, 10) : s;
            Console.WriteLine(s);
            return;

            try
            {
                throw new Exception("sadfasdf");
            }
            catch (Exception ex)
            {

                throw ex;
            }


            //WebClient web = new WebClient();
            //web.DownloadFile("http://images1.dzsofts.net/group_buy_image2.php?g=141946&i=10926858066&day&r=7623", "d:\\aa.gif");

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://img02.taobaocdn.com/imgextra/i2/1204883/T2yGF6XftbXXXXXXXX_!!1204883.gif");

            request.Timeout = 3000;
            WebResponse response = request.GetResponse();

            long imgLong = response.ContentLength;

            response.Close();


            return;
            //Task task = Task.Factory.StartNew(() => {
            //    for (int i = 0; i < 10; i++)
            //    {
            //        this.listBox1.Items.Add(i);
            //    }
            //});
            //var lists = System.IO.Directory.EnumerateFiles("e:\\");
            Action f = new Action(() =>
            {
                var lists = System.IO.Directory.GetFiles("F:\\SoftWare", "*.*", System.IO.SearchOption.AllDirectories);
                foreach (var a in lists)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.listBox2.Items.Add(a);
                    });
                }
                MessageBox.Show("2");
            });
            Action t = new Action(() =>
            {

                var lists = System.IO.Directory.EnumerateFiles("F:\\SoftWare", "*.*", System.IO.SearchOption.AllDirectories);
                foreach (var item in lists)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.listBox1.Items.Add(item);
                    });
                }
                MessageBox.Show("1");
            });
            f.BeginInvoke(null, null);
            t.BeginInvoke(null, null);
        }
    }
}
