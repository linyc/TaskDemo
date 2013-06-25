using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();

            MessageBox.Show("\\".Length.ToString());

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = sourcekv(); return;

            this.richTextBox1.Text = "http://static.googleadsserving.cn/pagead/imgad?id=CNLhmKSW5fbNBRCsAhj6ATIIrsMEwkooOyA";

            //string path = Application.StartupPath + "/img/20101110171310492181.jpg";
            string path = Application.StartupPath + "/img/table_bg.png";
            //this.webBrowser1.DocumentText = "<img src='" + path + "'/>";

            this.webBrowser1.DocumentText="<table><tr style='background:url("+path+") repeat-x; height:16px;'><td style='height:16px; line-height:16px;width:15%;'>帐户名称</td><td style='height:16px; line-height:16px;width:15%;'>店铺名称</td><td style='height:16px; line-height:16px;width:15%;'>所属类目</td><td style='height:16px; line-height:16px;width:10%;'>店铺类型</td><td style='height:16px; line-height:16px;width:10%;'>店铺状态</td><td style='height:16px; line-height:16px;width:10%;'>商品数量</td><td style='height:16px; line-height:16px;width:25%;'>客服列表</td></tr><tr><td style='line-height:16px;width:15%;'>testdd</td><td style='line-height:16px;width:15%;'>testdd</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>admin21</td><td style='line-height:16px;width:15%;'>admin21</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>testt11122</td><td style='line-height:16px;width:15%;'>testt11122旗舰店</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>testt111</td><td style='line-height:16px;width:15%;'>testt111</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>test111112</td><td style='line-height:16px;width:15%;'>test111112</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>cookietest</td><td style='line-height:16px;width:15%;'>cookieTest</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>ddfs_1111</td><td style='line-height:16px;width:15%;'>ddfs_1111</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>3</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>女衣号888</td><td style='line-height:16px;width:15%;'>女衣号888</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>1</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>doccrowntest</td><td style='line-height:16px;width:15%;'>docCrownTest</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>5</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr><tr><td style='line-height:16px;width:15%;'>doctest</td><td style='line-height:16px;width:15%;'>docTest</td><td style='line-height:16px;width:15%;'></td><td style='line-height:16px;width:10%;'>5</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:10%;'>0</td><td style='line-height:16px;width:25%;'><ul></ul></td></tr></table>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CalendarColumn col = new CalendarColumn();
            //this.dataGridView1.Columns.Add(col);
            //this.dataGridView1.RowCount = 5;
            //foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //{
            //    row.Cells[0].Value = DateTime.Now;
            //}
            //TextAndImageColumn imgcol = new TextAndImageColumn();
            //imgcol.Image = Image.FromStream(new WebClient().OpenRead("http://avatar.profile.csdn.net/8/6/5/1_liujt17.jpg"));
            DataGridViewTextBoxColumn tboxcol = new DataGridViewTextBoxColumn();
            this.dataGridView1.Columns.Add(tboxcol);
            this.dataGridView1.RowCount = 5;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //System.Drawing.Drawing2D.GraphicsContainer gCons = e.Graphics.BeginContainer();
            //e.Graphics.SetClip(e.CellBounds);
            //WebClient web = new WebClient();
            //Image img = Image.FromStream(web.OpenRead("http://avatar.profile.csdn.net/8/6/5/1_liujt17.jpg"));
            //e.Graphics.DrawImageUnscaled(img, e.CellBounds.Location);
            //e.Graphics.EndContainer(gCons);
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Rectangle r = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //webBrowser1.SetBounds(r.X + dataGridView1.Location.X, r.Y + dataGridView1.Location.Y, r.Width, r.Height);
            //webBrowser1.DocumentText="<a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin=1844991999&site=qq&menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=2:1844991999:41' alt='点击这里给我发消息' title='点击这里给我发消息'></a>";
            //webBrowser1.BringToFront();
            if (e.ColumnIndex == 1)
            {
                //dataGridView1.BeginEdit(true);
                DataGridViewCell l = dataGridView1.CurrentCell;
                if (l.Value == "ok")
                {
                    l.Value = "cccc";
                    this.dataGridView1.DataSource = sourceUser();
                }
                else
                {
                    l.Value = "ok";
                }
                //dataGridView1.EndEdit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.Equals("aAa"))
                {
                    dataGridView1.Rows[i].Cells[0].Value = "yes";
                }
            }
        }


        List<User> sourceUser() {
            List<User> uList = new List<User>();

            User u = new User { Name="aa",nikename="aAa" };
            uList.Add(u);
            u = new User { Name = "bb", nikename = "bBb" };
            uList.Add(u);
            return uList;
        }
        dynamic sourcekv()
        {
            var v = new Dictionary<int, string>();
            for (int i = 0; i < 5; i++)
            {
                v.Add(i, i.ToString());
            }

            return v.ToList();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.Equals("aAa"))
                {
                    dataGridView1.Rows[i].Cells[1].Value = "yes";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(this.numericUpDown1.Value));
        }
    }
}

class User
{
    public string Name { get; set; }
    public string nikename { get; set; }
}