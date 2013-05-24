using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpCookie cookie = new HttpCookie("myname");
        //cookie.Domain = "crossdo.com";
        //cookie.Values.Add("un", "cookietestname");
        //cookie.Values.Add("pwd", "iampwd");
        //cookie.Expires = DateTime.Now.AddDays(1);
        //Response.Cookies.Add(cookie);
        CTool.CNet.HttpHelper cookie = new CTool.CNet.HttpHelper();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("uname", "coname");
        dic.Add("upwd", "copwd");
        cookie.SetCookies("haha", dic, null, "crossdo.com");

        Response.Write("set cookie success");
    }
}