<%@ Page Title="Your playlists" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playlists.aspx.cs" Inherits="AnySystem.Web.Profile.Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage your videos</h2>
    <asp:ListView runat="server"
        ID="lv_playlists"
        SelectMethod="SelectPlaylists"
        DataKeyNames="Id"
        DataMember="Id"
        ItemType="AnySystem.Web.Models.PlaylistViewModel">
        <ItemTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="text-center"><%#: Item.Title %> &nbsp; <asp:Button runat="server" ID="btnDelete" OnCommand="btnDelete_OnCommand" CommandName="Delete" CommandArgument="<%# Item.Id %>" CssClass="btn btn-danger btn-sm" Text="X" /></h3>
                </div>
                <div class="panel-body">
                    <div style="margin: 0 auto">
                        <ul class="list-group">
                        <asp:Repeater runat="server"
                            ItemType="AnySystem.Data.Models.Video"
                            DataSource='<%# GetPlaylistVideos(Item.Id) %>'>
                            <ItemTemplate>
                                <li class="list-group-item">
                                    <p class="text-center"><a href="<%#: Item.Url %>"><%#: Item.Url %></a> &nbsp;&nbsp;<asp:Button runat="server" ID="btnDeleteVideo" CommandName="Delete" CommandArgument="<%# Item.Id %>" OnCommand="btnDeleteVideo_OnCommand" Text="Delete" CssClass="btn btn-danger btn-sm"/></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                            </ul>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
