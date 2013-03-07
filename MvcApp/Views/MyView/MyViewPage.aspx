<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MyViewPage</title>
    <style type="text/css">
    .txt{width:300px}
    </style>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.form.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnMVC").click(function () {
                //                $.ajax({
                //                    url: "/myview/add",
                //                    data: { a: 1, b: 4 },
                //                    success: function (result) {
                //                        $("#mvcRet").text(result);
                //                    }
                //                });

                var cus = { Name: "hehi", Sex: 2, Age: 33 };
                $.ajax({
                    url: "/myview/GetMsg",
                    data: cus,
                    success: function (result) {
                        $("#mvcRet").text(result);
                    }
                });

                $("frm1").ajaxForm(function (result) {
                    $("#txtareaRet").text(result);
                });
            });
        });
    </script>
</head>
<body>
    <div>
    <input type="button" value="MVCAjax" id="btnMVC" />
    <span id="mvcRet"></span>
    </div>
    <hr />
    <div>
    <form id="frm1" action="/myview">
    Input :<input type="text" name="txtinput" class="txt" value="test String" /><br />
    Output:<input type="text" id="txtareaRet" name="txtareaRet" class="txt" readonly="readonly" /><br />
    <input type="submit" name="base64" value="转成base64" />
    <input type="submit" name="md5" value="转成md5" />
    <input type="submit" name="hash" value="转成hash" />
    </form>
    </div>
</body>
</html>
