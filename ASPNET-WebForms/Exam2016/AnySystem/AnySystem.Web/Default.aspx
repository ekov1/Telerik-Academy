<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnySystem.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">
        Top 10 playlists rated by our users
    </h1>
    <hr />
    <div class="row">
        <asp:ListView runat="server" ID="lv_top"
            ItemType="AnySystem.Web.Models.PlaylistViewModel"
            SelectMethod="lv_top_Select">
            <ItemTemplate>
                <div class="col-md-4 col-lg-3 text-center">
                    <h4 class="text-center"><a href="/Details?id=<%# Item.Id %>"><%#: Item.Title %></a></h4>
                    <p>Category: <a href="/Playlists/ByCategory?id=<%# Item.CategoryId %>"><%#: Item.Category %></a></p>
                    <small>by: <%#: Item.Author %></small>
                    <p><span class="glyphicon glyphicon-star"></span>&nbsp;<%# Item.Rating %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
