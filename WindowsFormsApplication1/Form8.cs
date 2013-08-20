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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode("a");
            tn.Name = "a";
            TreeNode tn1 = tn.Nodes.Add("a1");
            tn1.Name = "a1";
            tn.Nodes.Add("a2").Name = "a2";
            tn.Nodes.Add("a3").Name = "a3";

            tn1.Nodes.Add("a1-1").Name = "a1-1";

            this.treeView1.Nodes.Add(tn);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Console.WriteLine(e.Item.GetType().ToString());

                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.Action == DragAction.Continue)
            {

            }
        }
        Point p = new Point(0, 0);
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode myNode = null;
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                myNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                p.X = e.X;
                p.Y = e.Y;
                p = this.treeView1.PointToClient(p);
                TreeNode targetNode = this.treeView1.GetNodeAt(p);
                if (targetNode != null && targetNode.Parent != myNode && targetNode != myNode)
                {
                    TreeNode tmpNode = myNode;
                    myNode.Remove();
                    targetNode.Nodes.Add(tmpNode);
                }
                if (targetNode == null)
                {
                    TreeNode tmpNode = myNode;
                    myNode.Remove();
                    this.treeView1.Nodes.Add(tmpNode);
                }

                this.treeView1.ExpandAll();
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
