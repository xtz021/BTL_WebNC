<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Content_Article.aspx.cs" Inherits="BTL_WebNC.FrontEnd.Content_Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">
    <asp:Repeater runat="server" ID="rptContent">
        <ItemTemplate>
            <div class="modal-content well">
                <h4><a href="KindArticle.aspx?tt=<%# Eval("FK_iTheloaiID") %>"><%# Eval("sTenTheloai") %></a></h4>
                <h2><%# Eval("sTieude") %></h2>
                <p>
                    Cập nhật:<%# Eval("dNgaydang","{0:MMMM d, yyyy}") %><br />
                    Số lần xem: <%# Eval("iLanxem") %>
                </p>
                <h4><%# Eval("sMota") %></h4>
                <div><%# Eval("sNoidung") %></div>
                <h4 class="text-right" style="padding-right:5px;"><%# Eval("sHoten") %></h4>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
