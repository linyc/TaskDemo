using System;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.coboxType.SelectedIndex = 0;
            this.webBrowser1.ScriptErrorsSuppressed = false;
        }

        void Login()
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("http://ptlogin2.paipai.com/login?u=1844991999&p=A5451B95A4788A51E8392492F8CFA31D&verifycode=!AVH&aid=17000101&u1=http://member.paipai.com/cgi-bin/ptlogin?loginfrom=18&h=1&ptredirect=0&ptlang=2052&from_ui=1&dumy=&fp=loginerroralert&action=2-14-51904&mibao_css=&t=1&g=1&js_type=0&js_ver=10015&login_sig=ozfqYuzinheRyowjFvyzchwyFVYl9pHaAQTaSWoUNYDkW-dmSwSmkhlo3Y2QUaMM");
            webrequest.Method = "GET";
            webrequest.Accept = "*/*";
            //webrequest.Proxy = new WebProxy("192.168.0.217", 8088);
            webrequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; InfoPath.3; .NET4.0C; .NET4.0E)";
            webrequest.Referer = "http://ui.ptlogin2.paipai.com/cgi-bin/login?appid=17000101&style=0&target=self&no_verifyimg=1&hide_title_bar=1&f_url=loginerroralert&link_target=blank&uin=&s_url=http://member.paipai.com/cgi-bin/ptlogin?loginfrom=18&css=http://imgcache.qq.com/ptcss/b2/paipai/17000101/login_2.css?tmp=201105241407&tmp=201105241407";
            webrequest.Host = "ptlogin2.paipai.com";
            webrequest.ContentType = "text/html;charset=UTF-8";
            CookieContainer myCookie = new CookieContainer();
            string cookie="PPRD_P=PD.40007.1.1-IA.20084.1.3-CT.33485.14.1; pgv_pvid=1856495892; pgv_info=ssid=s3686588167; g_pvid=6378555280820835713578707663407; visitkey=63785552808208357; buy_uin=1844991999; ptisp=ctc; verifysession=h00a4fc1b3adc33bd4249b338121cdb18d244d2367f31d18f964badf5133a0a9e0c366c7352d6f5abd031550c3dfa1a8ed1; ptui_loginuin=1844991999; pt2gguin=o1844991999; mp=; selleruin=0; buy_area=cn; uin=; skey=; hs=; returnurl=; uikey=1c502591988375f0f56246866c781c9d63e7b65f33be9cb025dc0c9e247a15f8; chkuin=1844991999; confirmuin=1844991999; ETK=; ptuserinfo=e6b2a7; ptcz=a313edf7cdcf4e4f87f75ed94ac5cad10bc92b9cead0152fc35794899ab207c0; ptvfsession=aa1dd0caeda0181466b0aa030a890af427ab737d7f7f2809ed3d6695e8a5b093fbf026cc2913d5c27ba3fe9a3b8e553b";
            myCookie.SetCookies(new Uri("http://ptlogin2.paipai.com"), cookie);
            webrequest.CookieContainer = myCookie;

            using (WebResponse webresp = webrequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(webresp.GetResponseStream(), Encoding.UTF8))
                {
                    this.txtResponse.Text = sr.ReadToEnd();
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Login();

            string request = this.txtRequest.Text;
            request = string.Format(request, new Random(DateTime.Now.GetHashCode()).NextDouble());
            string type = this.coboxType.Text;
            string frequency = this.txtFrequency.Text;
            string cookie = this.txtCookie.Text;
            string host="party.paipai.com";

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(request);
            webrequest.Method = type;       
            webrequest.Accept = "*/*";
            webrequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; InfoPath.3; .NET4.0C; .NET4.0E)";
            webrequest.Referer = "http://www.paipai.com/promote/2012/index_267.shtml?byref=1&g_tk=2073776092&g_ty=lk";
            webrequest.Host = host;
            webrequest.ContentType = "text/html";
            //webrequest.Proxy = new WebProxy("192.168.0.217", 8088);
            CookieContainer myCookie = new CookieContainer();
            //string cookie = "PPRD_P=PD.40007.1.1-IA.20084.1.3-CT.33485.14.1; pgv_pvid=1856495892; pgv_info=ssid=s3686588167; g_pvid=6378555280820835713578707663407; visitkey=63785552808208357; buy_uin=1844991999; ptisp=ctc; verifysession=h00a4fc1b3adc33bd4249b338121cdb18d244d2367f31d18f964badf5133a0a9e0c366c7352d6f5abd031550c3dfa1a8ed1; ptui_loginuin=1844991999; pt2gguin=o1844991999; mp=; selleruin=0; buy_area=cn; uin=; skey=; hs=; returnurl=; uikey=1c502591988375f0f56246866c781c9d63e7b65f33be9cb025dc0c9e247a15f8; chkuin=1844991999; confirmuin=1844991999; ETK=; ptuserinfo=e6b2a7; ptcz=a313edf7cdcf4e4f87f75ed94ac5cad10bc92b9cead0152fc35794899ab207c0; ptvfsession=aa1dd0caeda0181466b0aa030a890af427ab737d7f7f2809ed3d6695e8a5b093fbf026cc2913d5c27ba3fe9a3b8e553b";

            myCookie.SetCookies(new Uri("http://"+host), cookie);
            webrequest.CookieContainer = myCookie;

            using (WebResponse webresp = webrequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(webresp.GetResponseStream(),Encoding.UTF8))
                {
                    this.txtResponse.Text = sr.ReadToEnd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://login.cn100.com/Login.aspx?ReturnUrl=");
            request.CookieContainer = cookie;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:18.0) Gecko/20100101 Firefox/18.0";
            //request.Proxy = new WebProxy("192.168.0.217", 8088);
            byte[] bs =Encoding.ASCII.GetBytes("UserName=uupro&UserPWD=123456");
            request.ContentLength = bs.Length;
            using (Stream s = request.GetRequestStream())
            {
                s.Write(bs, 0, bs.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            request = (HttpWebRequest)WebRequest.Create("http://product.cn100.com/Freight/FreightTemplates.aspx");
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookie;
              response = (HttpWebResponse)request.GetResponse();
            string reback = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                reback = sr.ReadToEnd();
            }

            this.webBrowser1.DocumentText = reback;
        }
    }
}
