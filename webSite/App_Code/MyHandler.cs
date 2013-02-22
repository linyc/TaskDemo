using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

/// <summary>
///MyHandler 的摘要说明
/// </summary>
public class MyHandler:IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Write("hello:"+context.Request["val"]);
    }
}