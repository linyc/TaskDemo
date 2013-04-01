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
        HttpCookie cookie = new HttpCookie("myname");
        cookie.Domain = "crossdo.com";
        cookie.Values.Add("un", "cookietestname");
        cookie.Values.Add("pwd", "iampwd");
        cookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie);

        Response.Write("set cookie success");
    }
}