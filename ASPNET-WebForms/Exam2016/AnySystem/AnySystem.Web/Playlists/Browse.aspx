<%@ Page Title="Browse playlists" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="AnySystem.Web.Playlists.Browse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Browse Playlists</h2>
        </div>
        <div class="panel-body">
            <div>
                <span class="text-primary">Search by keyword:&nbsp;&nbsp;&nbsp;</span>
                <asp:TextBox runat="server" ID="searchContains"></asp:TextBox>
                <asp:Button runat="server" OnClick="SearchContains_OnClick" Text="Search" CssClass="btn btn-default btn-sm"/>
            </div>
            <hr />
            <asp:GridView runat="server"
                ItemType="AnySystem.Data.Models.Playlist"
                AllowPaging="true"
                PageSize="10"
                AllowSorting="true"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                CssClass="table table-hover table-striped table-responsive"
                ID="gvPlaylists"
                SelectMethod="Select">
                <Columns>
                    <asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                            <%#: GetAuthorName(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Title" SortExpression="Title" DataField="Title" />
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <%#: GetCategoryName(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Videos">
                        <ItemTemplate>
                            <%#: GetVideosCount(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <%#: GetRating(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Created" SortExpression="CreatedOn" DataField="CreatedOn" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
