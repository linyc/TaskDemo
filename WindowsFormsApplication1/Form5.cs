using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = folder.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                if (!Directory.Exists(this.textBox2.Text))
                    Directory.CreateDirectory(this.textBox2.Text);

                string urls = this.textBox1.Text;
                if (!string.IsNullOrEmpty(urls))
                {
                    using (StringReader sr = new StringReader(urls))
                    {
                        string s = string.Empty;
                        WebClient web = new WebClient();
                        int i = 0;
                        while ((s = sr.ReadLine()) != null)
                        {
                            string downUrl = s;
                            if (s.Contains('_'))
                            {
                                downUrl = downUrl.Substring(0,downUrl.LastIndexOf('_'));
                            }
                            web.DownloadFile(downUrl, this.textBox2.Text + "\\" + Path.GetFileName(downUrl));
                            this.label2.Text = (++i).ToString();
                            Application.DoEvents();
                        }
                    }
                }
            }
        }
    }
}
