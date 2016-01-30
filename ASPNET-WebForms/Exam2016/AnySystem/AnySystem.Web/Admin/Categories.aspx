<%@ Page Title="Manage Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="AnySystem.Web.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage Categories</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="AnySystem.Data.Models.Category"
                ID="gvCategories"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                DataKeyNames="Id"
                SelectMethod="Select"
                UpdateMethod="Update"
                AutoGenerateColumns="false"
                CssClass="table table-hover table-striped table-responsive">
                <Columns>
                    <asp:BoundField SortExpression="Id" HeaderText="Id" DataField="Id" ReadOnly="True" />
                    <asp:BoundField SortExpression="Name" HeaderText="Name" DataField="Name" />
                    <asp:TemplateField HeaderText="Count">
                        <ItemTemplate>
                            <%# GetPlaylistsInCategory(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                </Columns>
            </asp:GridView>
            <div class="text-center">
                <asp:Literal Text="Category name is mandatory!" runat="server" ID="literalMsg" Visible="False" />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <h4>Add Category:</h4>
                        <p>
                            Category name:
                            <asp:TextBox runat="server" ID="newCategory" />
                        </p>
                        <asp:Button Text="Add" runat="server" ID="BtnAdd" OnClick="BtnAdd_OnClick" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger runat="server" ControlID="BtnAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
