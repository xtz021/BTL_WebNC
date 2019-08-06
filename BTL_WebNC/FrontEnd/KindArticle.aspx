<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/FrontEnd.Master" AutoEventWireup="true" CodeBehind="KindArticle.aspx.cs" Inherits="BTL_WebNC.FrontEnd.KindArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">
    <div class="menubar row col-lg-7">
        <div id="top5News" class="col-lg-12">
            <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                    <a href="Content_Article.aspx?tl=<%# Eval("FK_iTheloaiID") %>&tt=<%# Eval("PK_iBaivietID") %>">
                        <h2><%#Eval("sTieude") %></h2>
                        <p><%#Eval("sMota") %></p>
                        <img style="width: 100%;" src="../<%#Eval("surlAnh") %>" />
                    </a>
                </ItemTemplate>
            </asp:Repeater>
             <div class="col-12 center margin-top page">
            <asp:HyperLink ID="lnkPre" runat="server" CssClass="pre_next">Trang trước</asp:HyperLink>
              <asp:HyperLink ID="lnkStart" runat="server" CssClass="index">1</asp:HyperLink>
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             <asp:HyperLink ID="lnkEnd" runat="server" CssClass="index">11</asp:HyperLink>
            <asp:HyperLink ID="lnkNext" runat="server" CssClass="pre_next">Trang sau</asp:HyperLink>
        </div>
        </div>
    </div>
    <div class="col-lg-5 row border">
        <div class="col-lg-10 center">
            <div>
                <h2>Tin mới nhất</h2>
                <asp:Repeater runat="server" ID="rptNewestArticle">
                    <ItemTemplate>
                        <a href="Content_Article.aspx?tl=<%# Eval("FK_iTheloaiID") %>&tt=<%# Eval("PK_iBaivietID") %>">
                            <h3><%#Eval("sTieude") %></h3>
                            <p><%#Eval("sMota") %></p>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
