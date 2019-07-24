<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTL_WebNC.FrontEnd.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">
    <style>
        .center{
            margin-left:50%;
            transform:translateX(-50%);
        }
    </style>
    <div class="container navbar-text well center content">
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
