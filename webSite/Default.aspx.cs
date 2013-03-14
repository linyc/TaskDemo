using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected string ItemVal;
    protected string ParamsVal;

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] allKeys = Request.QueryString.AllKeys;
        if (allKeys.Length == 0)
            Response.Redirect("/webSite/Default.aspx?kk=wsx", true);

        ItemVal = Request["kk"];
        ParamsVal = Request.Params["kk"];

        Response.TransmitFile(Server.MapPath("~/scripts/jquery.form.js"));
    }
}