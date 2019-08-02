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
            <div>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="User name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Error: User name" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
            </div>
        <div class="form-group">
            <b><asp:Label Text="Password" ID="lbPass" runat="server" /></b>
            <asp:TextBox ID="txtPass" type="password" runat="server" class="form-control" placeholder="password" TextMode="SingleLine"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPass" ErrorMessage="Error: Password" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(?=.*[a-z])(?=.*[0-9]).{6,}$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <b><asp:Label Text="Re-enter Password" ID="lbRePass" runat="server" /></b>
            <asp:TextBox ID="txtRePass" type="password" runat="server" class="form-control" placeholder="password" TextMode="SingleLine"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToCompare="txtPass" ControlToValidate="txtRePass" ErrorMessage="Does not match password" ForeColor="Red" SetFocusOnError="True">*</asp:CompareValidator>
        </div>
        <div class="form-group">
            <label for="txtHoten">Họ tên</label>
            <asp:TextBox ID="txtHoten" runat="server" class="form-control" placeholder="Họ tên"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHoten" ErrorMessage="Error: Họ tên" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-6">
                    <label>Giới tính</label><br>
                        <asp:RadioButton ID="rbtnam" runat="server" Checked="True" GroupName="gioitinh" Text="Nam" />
                    <asp:RadioButton ID="rbtnu" runat="server" GroupName="gioitinh" Text="Nữ" />
                </div>
                <div class="col-lg-6">
                    <label for="ngaysinh">Ngày sinh</label>
                    <asp:TextBox ID="txtNgaysinh" type="date" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" HeaderText="List Error:" ShowMessageBox="True" />
        <asp:Button runat="server" CssClass="btn btn-info btn-rounded btn-block center" ID="btnAdd" Text="ADD" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
