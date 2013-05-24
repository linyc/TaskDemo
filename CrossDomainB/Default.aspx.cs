using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics.Contracts;

public partial class _Default : System.Web.UI.Page
{
    System.Threading.Timer t;
    protected void Page_Load(object sender, EventArgs e)
    {
        //string a = HttpRuntime.AppDomainAppPath;
        //Response.Write(a);
        //string b = System.Web.Hosting.HostingEnvironment.MapPath("~");
        //Response.Write(b);

        return;

        //var v = Request.Cookies["myname"];
        CTool.CNet.HttpHelper co = new CTool.CNet.HttpHelper();
        var v = co.GetCookies("haha");
        if (v != null)
            Response.Write(v[0] + '|' + v[1]);

        Contract.Ensures(v == null, "obj is null");

        t = new System.Threading.Timer(callback, null, 100, 1000);

    }

    void callback(object obj)
    {
        Contract.Requires(obj == null, "obj is null");

        HttpContext hc = HttpContext.Current;
        if (hc != null)
            Response.Write(hc.Request.MapPath("~"));

        string p1 = HttpRuntime.AppDomainAppPath;
        string p2 = HttpRuntime.AppDomainAppVirtualPath;
        string p3 = System.Web.Hosting.HostingEnvironment.MapPath("~");
        File.AppendAllText(Path.Combine(p1, "aa.txt"), string.Format("p1:{0}\tp2:{1}\tp3:{2}\r\n", p1, p2,p3));
    }
}