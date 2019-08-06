<%@ Page Title="User" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BTL_WebNC.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p><a href="Add_Edit_Users.aspx?kind=1" class="btn btn-primary btn-lg">Add &raquo;</a></p>
    <h3>Danh sách Users</h3>
    <div class<asp:GridView ID="gvUsers" runat="server" CellPadding="10" CssClass="center" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CellSpacing="10"
            DataKeyNames="PK_iUserID" OnRowCommand="gvUsers_RowCommand" OnRowDeleting="gvUsers_RowDeleting">
        <asp:GridView ID="gvUsers" runat="server" CellPadding="10" CssClass="center" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CellSpacing="10"
            DataKeyNames="PK_iUserID" OnRowCommand="gvUsers_RowCommand" OnRowDeleting="gvUsers_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PK_iUserID" HeaderText="Mã User" SortExpression="PK_iUserID" ReadOnly="True" />
                <asp:BoundField DataField="sUserName" HeaderText="Username" SortExpression="sUserName" ReadOnly="True" />
                <asp:BoundField DataField="sPass" HeaderText="Password" SortExpression="sPass" ReadOnly="True" />
                <asp:TemplateField HeaderText="Họ tên">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("sHoten") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("sHoten") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ControlStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Giới tính">
                    <ItemTemplate>
                        <%# (bool) Eval("bGioitinh")==false?"Nữ":"Nam" %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Nam/Nữ" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày sinh">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("dNgaysinh") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("dNgaysinh") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trạng thái">
                    <ItemTemplate>
                        <%# (bool) Eval("bTrangthai")==false?"Dừng hoạt động":"Hoạt động" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                        <a href="Add_Edit_Users.aspx?kind=2&tt=<%# Eval("PK_iUserID") %>">Sửa</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkbtn2" runat="server" CommandArgument='<%# Eval("PK_iUserID") %>'
                            CommandName="Delete" OnClientClick="return confirm(&quot;Có chắc chắn muốn xoá không?&quot;);" ToolTip="Delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quyền">
                    <ItemTemplate>
                        <%# Eval("stenquyen") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    <button onclick="get2()">BTON</button>
    <div id="div1"></div>
</asp:Content>
