<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Phan_Quyen.aspx.cs" Inherits="BTL_WebNC.Phan_Quyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container navbar-text well">
        <h4 class="text-center">Lựa chọn Quyền</h4>
        <div class="form-group text-center">
            <asp:DropDownList runat="server" CssClass="from_control" ID="drdlPhanquyen">
            </asp:DropDownList>
            <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnUpdate" Text="UPDATE" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
