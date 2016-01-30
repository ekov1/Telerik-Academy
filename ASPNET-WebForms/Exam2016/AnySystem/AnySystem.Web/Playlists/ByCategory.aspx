<%@ Page Title="Category playlists lookup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ByCategory.aspx.cs" Inherits="AnySystem.Web.Playlists.ByCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Viewing Playlists in Category</h2>
    <div class="row">
        <asp:ListView runat="server" ID="lv_categories"
            ItemType="AnySystem.Web.Models.PlaylistViewModel"
            SelectMethod="lv_categories_select">
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
