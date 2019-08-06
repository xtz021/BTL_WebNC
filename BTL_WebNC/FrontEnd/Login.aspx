<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL_WebNC.FrontEnd.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">
    <style>
        .center{
            margin-left:20%;
            transform:translateX(-20%);
        }
    </style>
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
</asp:Content>
