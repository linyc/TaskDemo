<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript">
        $(document).ready(
        function () {
            $("#btnSub").click(function () {
                var name = $("#txtName").val();
                $.post("/webSite/JsHandler.ashx"
                , { val: name }
                , function (res) {
                    alert(res);
                    $("#ret").html(res);
                }
                , "json");
//                $.ajax({ url: '/webSite/AjaxGet.cc'
//                    , data: { val: name }
//                    , success: function (data) {
//                        $("#ret").html(data);
//                    }
//                });
            }
        )
        }
        //document.cookie="cc=asdfsadf;path=/";
        );
    </script>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
    <input type="text" id="txtName" />
    <input type="button" id="btnSub" value="click me" />
    <div id="ret"> </div>
    </form>
</body>
</html>
