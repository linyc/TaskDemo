using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.IO.Compression;
using System.IO;

/// <summary>
///MyHandler 的摘要说明
/// </summary>
public class MyHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Write("hello:"+context.Request["val"]);
        //GzipRequest2(context);
    }

    private void GzipRequest1(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        string input = null;

        JavaScriptSerializer jsonSeri = new JavaScriptSerializer();

        using (GZipStream gzip = new GZipStream(context.Request.InputStream, CompressionMode.Decompress))
        {
            using (StreamReader sr = new StreamReader(gzip))
            {
                input = sr.ReadToEnd();
            }
        }

        QueryParams Qparams = jsonSeri.Deserialize<QueryParams>(input);
        List<Order> orderList = new List<Order>();
        for (int i = 0; i < 10; i++)
        {
            orderList.Add(new Order { Id = i, OrderTime = DateTime.Now, OrderDetail = new OrderDetail { Count = i * 2, DetId = i + 1, ProductName = "hhhhaaa" + i } });
        }

        string ret = jsonSeri.Serialize(orderList);
        using (GZipStream gzip = new GZipStream(context.Response.OutputStream, CompressionMode.Compress))
        {
            using (StreamWriter sw = new StreamWriter(gzip))
            {
                context.Response.AddHeader("Content-Encoding", "gzip");
                sw.Write(ret);
            }
        }
    }

    private void GzipRequest2(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        string input = null;
        JavaScriptSerializer jsonSeri = new JavaScriptSerializer();

        bool enableGzip=context.Request.Headers["Content-Encoding"] == "gzip";
       
        if (enableGzip)
            context.Request.Filter = new GZipStream(context.Request.Filter, CompressionMode.Decompress);

        using (StreamReader sr=new StreamReader(context.Request.InputStream))
        {
            input = sr.ReadToEnd();
        }

        QueryParams Qparams = jsonSeri.Deserialize<QueryParams>(input);
        List<Order> orderList = new List<Order>();
        for (int i = 0; i < 10; i++)
        {
            orderList.Add(new Order { Id = i, OrderTime = DateTime.Now, OrderDetail = new OrderDetail { Count = i * 2, DetId = i + 1, ProductName = "hhhhaaa" + i } });
        }

        if (enableGzip)
        {
            context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
            context.Response.AddHeader("Content-Encoding", "gzip");
        }

        using (StreamWriter sw=new StreamWriter(context.Response.OutputStream))
        {
            string ret = jsonSeri.Serialize(orderList);
            sw.Write(ret);
        }
    }
}