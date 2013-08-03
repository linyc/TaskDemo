using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.ServiceModel;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class FrmWCFMonitor : Form
    {

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        Dictionary<string, string> dicWcf = new Dictionary<string, string>();

        public FrmWCFMonitor()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            StartMonitor();
        }
        void StartMonitor()
        {
            foreach (var item in dicWcf)
            {
                ThreadPool.QueueUserWorkItem(ExecCallback, new KeyValuePair<string, string>(item.Key, item.Value));
            }
        }

        void ExecCallback(object obj)
        {
            KeyValuePair<string, string> kv = (KeyValuePair<string, string>)obj;

            int retrytime = Convert.ToInt32(this.txtRetryTime.Text);

            for (int i = 0; i < retrytime; i++)
            {
                if (kv.Key.ToLower().StartsWith("http://"))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(kv.Key);
                    //request.Timeout = 3000;
                    try
                    {
                        var response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return;
                        }
                    }
                    catch (WebException)
                    {
                    }
                }
                else if (kv.Key.ToLower().StartsWith("net.tcp://"))
                {
                    string uri = kv.Key.ToLower();
                    uri = uri.Substring(uri.IndexOf("net.tcp://") + 10, uri.Length - uri.LastIndexOf("/") - 1);
                    string[] hostAndPort = uri.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    string host = hostAndPort[0];
                    string port = string.Empty;

                    if (hostAndPort.Length == 2)
                    {
                        port = hostAndPort[1];
                    }

                    TcpClient tcp = new TcpClient();
                    try
                    {
                        tcp.Connect(new IPEndPoint(IPAddress.Parse(host), Convert.ToInt32(port)));
                        return;
                    }
                    catch(SocketException){
                        
                    }
                    //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //sock.Connect(host, Convert.ToInt32(port));
                    //if (sock.Connected)
                    //{
                    //    byte[] bs = new byte[1];
                    //    sock.SendTo(bs, new IPEndPoint(IPAddress.Parse(host), Convert.ToInt32(port)));
                    //    int rec = sock.Receive(bs, SocketFlags.None);
                    //    Console.WriteLine(rec);
                    //}
                }
                Thread.Sleep(1000);
            }

            var pros = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(kv.Value));
            foreach (var pro in pros)
            {
                string file = pro.MainModule.FileName;

                if (file == kv.Value)
                    pro.Kill();
            }
            Thread.Sleep(1000);
            Process.Start(new ProcessStartInfo(kv.Value));
        }

        private void btnSelectExeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtExeFilePath.Text = ofd.FileName;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtWcfServiceUri.Text) || string.IsNullOrWhiteSpace(this.txtExeFilePath.Text))
            {
                MessageBox.Show("服务地址和程序路径都不能为空");
                return;
            }
            else if (!this.txtWcfServiceUri.Text.StartsWith("net.tcp://") && !this.txtWcfServiceUri.Text.StartsWith("http://"))
            {
                MessageBox.Show("服务地址开头没有包含 \"net.tcp://\" 或 \"http://\"");
                return;
            }
            if (!dicWcf.ContainsKey(this.txtWcfServiceUri.Text))
            {
                ListViewItem lvi = new ListViewItem(this.txtWcfServiceUri.Text);
                lvi.SubItems.Add(this.txtExeFilePath.Text);
                this.listView1.Items.Add(lvi);
                dicWcf.Add(this.txtWcfServiceUri.Text.Trim(), this.txtExeFilePath.Text.Trim());
            }
        }
        int status = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dicWcf.Count == 0)
            {
                MessageBox.Show("监控列表为空");
                return;
            }
            if (status == 0)
            {
                timer.Interval = (int)(Convert.ToDecimal(this.txtInterval.Text) * 60 * 1000);
                timer.Start();

                this.btnStart.Text = "停止监控";
                status = 1;
            }
            else
            {
                timer.Stop();

                this.btnStart.Text = "启动监控";
                status = 0;
            }
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                while (this.listView1.SelectedItems.Count > 0)
                {
                    dicWcf.Remove(this.listView1.SelectedItems[0].Text);
                    this.listView1.SelectedItems[0].Remove();
                }
            }
        }
    }
}
