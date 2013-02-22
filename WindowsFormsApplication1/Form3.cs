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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            for (int i = 0; i < int.Parse(this.textBox1.Text); i++)
            {
                MethodInvoker mi = () =>
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.treeView1.Nodes.Add(new TreeNode(i.ToString()));
                            }, null);
                        }
                        else
                        {
                            this.treeView1.Nodes.Add(new TreeNode(i.ToString()));
                        }
                    };
                mi.BeginInvoke(ia => { mi.EndInvoke(ia); }, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(this.textBox1.Text); i++)
            {
                Label lbl = new Label();
                lbl.Text = i.ToString();
                lbl.Name = i.ToString();
                this.panel1.Controls.Add(lbl);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //foreach (Control item in this.panel1.Controls)
            //{
            //    item.Dispose();
            //}
            this.panel1.Dispose();
        }
    }
}
