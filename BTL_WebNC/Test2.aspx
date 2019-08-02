<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="BTL_WebNC.Test2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="jquery-1.11.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Number 1
            <input type="text" id="txtnum1" />
            <br />
            Number 2
            <input type="text" id="txtnum2" />
            <br />
            <input type="button" id="cmdAdd" value="Add" />
            <input type="button" id="cmdSub" value="Sub" />
        </div>
    </form>

   
    <script>
        $("#cmdAdd").click(function () {
            alert("addd");
            $.ajax({
                type: "GET",
                url: "test2.aspx/add?num1=" + $("#txtnum1").val() + "&num2=" + $("#txtnum2").val(),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    alert(result.data);
                }
            });
        });

        $("#cmdSub").click(function () {
            alert("sub");
            var data = JSON.stringify({
                "num1": $('#txtnum1').val(),
                "num2": $('#txtnum2').val()
            });
            $.ajax({
                type: "POST",
                url: "test2.aspx/sub",
                contentType: "application/json;charset=utf-8",
                data: data,
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    alert(result.data);
                },
                error: function () { },
                complete: function () { }
            });
        });
    </script>
</body>
</html>
