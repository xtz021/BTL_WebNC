<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Add_Edit_Users.aspx.cs" Inherits="BTL_WebNC.Add_Edit_Users1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container navbar-text well">
        <h4>
            <asp:Label ID="lbloi" runat="server"></asp:Label></h4>
        <div class="form-group">
            <b><asp:Label Text="User name" ID="lbUser" runat="server" /></b>
            <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="User name"></asp:TextBox>
        </div>
        <div class="form-group">
            <b><asp:Label Text="PassWord" ID="lbPass" runat="server" /></b>
            <asp:TextBox ID="txtPass" type="password" runat="server" class="form-control" placeholder="password"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtHoten">Họ tên</label>
            <asp:TextBox ID="txtHoten" runat="server" class="form-control" placeholder="Họ tên"></asp:TextBox>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-6">
                    <label>Giới tính</label></br>
                        <asp:RadioButton ID="rbtnam" runat="server" Checked="True" GroupName="gioitinh" Text="Nam" />
                    <asp:RadioButton ID="rbtnu" runat="server" GroupName="gioitinh" Text="Nữ" />
                </div>
                <div class="col-lg-6">
                    <label for="ngaysinh">Ngày sinh</label>
                    <asp:TextBox ID="txtNgaysinh" type="date" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnAdd" Text="ADD" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
