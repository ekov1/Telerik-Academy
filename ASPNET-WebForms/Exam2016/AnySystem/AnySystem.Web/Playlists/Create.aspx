<%@ Page Title="Create Playlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="AnySystem.Web.Playlists.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server"
        ID="lVInsert"
        ItemType="AnySystem.Data.Models.Playlist"
        InsertMethod="fVInsert_InsertItem"
        SelectMethod="Select"
        InsertItemPosition="FirstItem">
        <InsertItemTemplate>
            <div class="panel panel-warning text-center" style="margin: 0  auto">
                <div class="panel-heading">
                    <h2>Create playlist</h2>
                </div>
                <div class="panel-body">
                    <h3>Title:
                <asp:TextBox runat="server" ID="tbInsertTitle" Text="<%#: BindItem.Title %>" />
                    </h3>
                    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Title is required!" ControlToValidate="tbInsertTitle" runat="server" EnableClientScript="false" />
                    <asp:CustomValidator ErrorMessage="Title too short!" ControlToValidate="tbInsertTitle" OnServerValidate="Unnamed_ServerValidate" runat="server" />
                    <p>
                        Category:
                <asp:DropDownList runat="server" ID="ddlCategories"
                    ItemType="AnySystem.Data.Models.Category"
                    DataValueField="Id"
                    DataTextField="Name"
                    SelectedValue="<%# BindItem.CategoryId %>"
                    SelectMethod="ddlCategories_GetData" />
                    </p>
                    <p>
                        Description:
                <asp:TextBox runat="server" ID="tbEditContent" Text="<%#: BindItem.Description %>" TextMode="MultiLine" Rows="5" Columns="100" />
                    </p>
                    <asp:Button Text="Create" CommandName="Insert" runat="server" CssClass="btn btn-success" />
                    <asp:Button Text="Cancel" OnClick="Unnamed_Click1" runat="server" CssClass="btn btn-danger" />
                </div>
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
