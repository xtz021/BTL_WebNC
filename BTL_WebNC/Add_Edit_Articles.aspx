<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Add_Edit_Articles.aspx.cs" Inherits="BTL_WebNC.Add_Edit_Articles" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container navbar-text well">
        <h4>
            <asp:Label ID="lbloi" runat="server"></asp:Label>

        </h4>
        <div class="form-group">
            <b>
                <asp:Label Text="Tiêu đề" ID="lbTieude" runat="server" /></b>
            <asp:TextBox ID="txtTieude" runat="server" class="form-control" placeholder="Tiêu đề"></asp:TextBox>
        </div>
        <div class="form-group">
            <b>
                <asp:Label Text="Mô tả" ID="lbMota" runat="server" /></b>
            <asp:TextBox ID="txtMota" runat="server" class="form-control" placeholder="Mô tả"></asp:TextBox>
        </div>
        <div class="form-group">
            <b>
                <asp:Label Text="Thể loại" ID="lbtTheloai" runat="server" /></b>
            <asp:DropDownList runat="server" class="form-control" ID="cboTheloai"></asp:DropDownList>
        </div>
        <div class="form-group">
            <b>
                <asp:Label Text="Nội dung" ID="lbNoidung" runat="server" /></b>
            <CKEditor:CKEditorControl ID="txtNoidung" runat="server"></CKEditor:CKEditorControl>
        </div>
        <div class="form-group">
            <asp:FileUpload ID="flAnhDaidien" runat="server" />
        </div>
        <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnAdd" Text="ADD" OnClick="btnAdd_Click" />
        <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnDuyet" Text="Duyệt" Visible="False" OnClick="btnDuyet_Click" />
    </div>
</asp:Content>
