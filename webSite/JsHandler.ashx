<%@ WebHandler Language="C#" Class="JsHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Collections.Generic;

public class JsHandler : IHttpHandler
{
    
    public void ProcessRequest(HttpContext context)
    {
        //System.Web.Caching.CacheDependency cd = new System.Web.Caching.CacheDependency(null, null);
        //System.Web.Caching.SqlCacheDependency sd = new System.Web.Caching.SqlCacheDependency(null);
        //WeakReference wrf = new WeakReference(cd);
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello " + context.Request["val"]);

        string text = context.Request["txt"];
        string radio = context.Request["rd"];
        string checkbox = context.Request["cbox"];
        string select = context.Request["sel"];
        string button = context.Request["btn"];
        HttpFileCollection files = context.Request.Files;
        //foreach (HttpPostedFile fileKey in files)
        //{
        //    fileKey.SaveAs(System.IO.Path.Combine(context.Server.MapPath("~/"), fileKey.FileName));
        //}
        for (int i = 0; i < files.Count; i++)
        {
            files[i].SaveAs(System.IO.Path.Combine(context.Server.MapPath("~/"), DateTime.Now.Ticks+files[i].FileName));
        }

        context.Request.Files["file1"].SaveAs(System.IO.Path.Combine(context.Server.MapPath("~/"), DateTime.Now.Ticks.ToString()));

        context.Response.Write(string.Format("{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}","<br/>", text, radio, checkbox, select,button,files.GetType()));
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}