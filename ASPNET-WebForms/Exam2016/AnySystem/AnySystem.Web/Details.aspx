<%@ Page Title="Playlist Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="AnySystem.Web.Playlists.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server"
        ID="fv"
        ItemType="AnySystem.Web.Models.PlaylistViewModel"
        SelectMethod="Select">
        <ItemTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3>Playlist <%#: Item.Title %>&nbsp;&nbsp;<span class="glyphicon glyphicon-star"><%# Item.Rating %></span></h3>
                </div>
                <div class="panel-body">
                    <p>Created: <%# Item.CreatedOn %></p>
                    <p>Author: <span class="text-faded"><%#: Item.Author %></span></p>
                    <p>Category: <a href="/Playlists/ByCategory?id=<%# Item.CategoryId %>"><%#: Item.Category %></a></p>
                    <p class="text-center well">
                        <%#: Item.Description %>
                    </p>
                    <div class="row" style="margin: 0  auto">
                        <asp:ListView runat="server" SelectMethod="GetPlaylistVideos"
                            ItemType="AnySystem.Data.Models.Video">
                            <ItemTemplate>
                                <div class="embed-responsive embed-responsive-4by3 col-md-3 col lg-4" style="margin-right: 40px">
                                    <iframe class="embed-responsive-item" src="<%#: Item.Url %>"></iframe>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <hr />
                    <div runat="server" id="ratingPanel" Visible="<%# Context.User.Identity.IsAuthenticated %>">
                        Rate: 
                        <asp:RadioButtonList runat="server" ID="rbl_rating" OnSelectedIndexChanged="rbl_rating_OnSelectedIndexChanged"/>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
