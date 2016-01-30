<%@ Page Title="Search by content" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AnySystem.Web.Playlists.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Search results for: <span runat="server" id="searchQueryText" class="text-info"></span></h2>
    <div class="row">
        <asp:ListView runat="server" ID="lv_results"
            ItemType="AnySystem.Web.Models.PlaylistViewModel"
            SelectMethod="lv_results_select">
            <EmptyItemTemplate>
                <h4 class="text-center">No playlists found.</h4>
            </EmptyItemTemplate>
            <EmptyDataTemplate>
                <h4 class="text-center">No playlists found.</h4>
            </EmptyDataTemplate>
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
