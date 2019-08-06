<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL_WebNC.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container login-container">
            <div class="row justify-content-center">
                <div class="col-lg-6 center">
                <h3>Login for Form</h3>
                    <div class="form-group">
                        <h4><asp:Label ID="lbloi" runat="server"></asp:Label></h4>
                    </div>
                <div class="form-group">
                    <b><asp:Label Text="User name" ID="lblUsername" runat="server" /></b>
                    <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Your User name *"></asp:TextBox>
                </div>
                <div class="form-group">
                    <b><asp:Label Text="User name" ID="Label1" runat="server" /></b>
                    <asp:TextBox ID="txtPass" type="password" runat="server" class="form-control" placeholder="Your Password *"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
