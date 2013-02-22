using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CN100.EnterprisePlatform.Utility;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            //string a = @"00120130114002\wew841ab80810364cdda764f259972f39bf.png";
            //string tmp = "ww";
            ////this.Text = a.Insert(a.LastIndexOf("\\")+1, tmp);
            //this.Text = a.Remove(a.LastIndexOf("\\") + 1, 2);
            //return;

            IDictionary<object, object> dicUsertype = CN100.EnterprisePlatform.Utility.EnumConvertUtils.ToDictionary<MemberType>();
            dicUsertype.Remove(2);
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.ValueMember = "Key";
            this.comboBox1.DataSource = dicUsertype.ToList();

            List<long> useridList = new List<long>();
            useridList.Add(12);
            useridList.Add(34);
            useridList.Add(56);

            this.Text = string.Join(",", useridList.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AsyncExec();
            return;
        }
        void AsyncExec()
        {

#if TRACE 
            File.AppendAllText("ccc.txt", string.Format("{0}\t{1}\n", DateTime.Now.Second, 4));
#endif

                Action act = () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    File.AppendAllText("ff.txt", string.Format("{0}\t{1}\n", DateTime.Now.Second, i));
                    System.Threading.Thread.Sleep(500);
                }
            };
            act.BeginInvoke(ia => { act.EndInvoke(ia); }, null);
        }
    }

    public enum MemberType
    {

        /// <summary>
        /// 会员
        /// </summary>
        [EnumValue(0, "会员")]
        Member = 0,

        /// <summary>
        /// 正式商家
        /// </summary>
        [EnumValue(1, "正式商家")]
        Business = 1,

        /// <summary>
        /// 商家子账号
        /// </summary>
        [EnumValue(2, "商家子账号")]
        SubAccount = 2,

        /// <summary>
        /// 待审核商家
        /// </summary>
        [EnumValue(3, "待审核商家")]
        AuditingBusiness = 3,

        /// <summary>
        /// 品牌类目已审核完毕，该商家作废
        /// </summary>
        [EnumValue(4, "作废商家账号")]
        BadBusiness = 4
    }
}
