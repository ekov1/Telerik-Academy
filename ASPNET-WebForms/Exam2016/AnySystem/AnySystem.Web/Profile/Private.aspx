<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Private.aspx.cs" Inherits="AnySystem.Web.Profile.Private" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server"
        ItemType="AnySystem.Data.Models.User"
        SelectMethod="SelectUser"
        UpdateMethod="UpdateUser">
        <ItemTemplate>
            <div class="panel panel-primary" style="margin: 0 auto; min-width: 500px">
                <div class="panel-heading">
                    <h2><%#: Item.FirstName %> <%#: Item.LastName %> &nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Edit" CommandName="Edit" runat="server" CssClass="btn btn-info" /><%--<a href="/Profile/EditProfile" class="btn btn-sm btn-raised btn-info">Edit</a>--%></h2>
                </div>
                <div class="text-center" style="padding-top: 10px">
                    <img src="<%#: Item.ProfileImageUrl %>" alt="<%#: Item.FirstName %>" width="300" height="300" runat="server" style="-ms-border-radius: 300px; border-radius: 300px" />
                </div>
                <br />
                <div class="text-center">
                    <div class="btn-group-sm">
                        <a href="<%#: Item.FacebookUrl %>" class="btn btn-sm btn-info"><i class="glyphicon glyphicon-link">&nbsp;</i>Facebook</a>
                        <a href="<%#: Item.YoutubeUrl %>" class="btn btn-sm btn-danger"><i class="glyphicon glyphicon-link">&nbsp;</i>Youtube</a>
                    </div>
                </div>
                <hr />
                <div class="text-center">
                    <div class="form-group has-warning">
                        <label class="col-lg-4 col-md-4 control-label">&nbsp;Email:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%#: Item.Email %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;First Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%#: Item.FirstName %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Last Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%#: Item.LastName %></label>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <hr />
                <div class="text-center">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            My Playlists: &nbsp;&nbsp;&nbsp; <a href="/Profile/Playlists" class="btn btn-sm btn-raised btn-info">Manage</a>
                        </div>
                        <div class="panel-body">
                            <asp:Repeater runat="server" ID="Repeater1" ItemType="AnySystem.Web.Models.PlaylistViewModel" SelectMethod="SelectPlaylists">
                                <HeaderTemplate>
                                    <table class="table table-responsive table-condensed table-hover">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="/Details?id=<%# Item.Id %>"><%#: Item.Title %></a></td>
                                        <td>
                                            <a href="/Playlists/ByCategory?id=<%# Item.CategoryId %>"><%#: Item.Category %></a>
                                        </td>
                                        <td>
                                            <span class="glyphicon glyphicon-star"></span>&nbsp;<%# Item.Rating %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="panel panel-primary" style="margin: 0 auto;">
                <div class="panel-heading">
                    <h2><%#: Item.FirstName %> <%#: Item.LastName %> &nbsp;&nbsp;&nbsp;</h2>
                </div>
                <div class="text-center" style="padding-top: 10px">
                    <img src="<%#: Item.ProfileImageUrl %>" alt="<%#: Item.FirstName %>" width="300" height="300" runat="server" style="-ms-border-radius: 300px; border-radius: 300px" />
                </div>
                <br />
                <div class="text-center">
                    <div>
                        <p>
                            Facebook:
                            <asp:TextBox runat="server" ID="TextBox1" Text="<%#: BindItem.FacebookUrl %>" />
                        </p>
                        <p>
                            Youtube:
                            <asp:TextBox runat="server" ID="TextBox2" Text="<%#: BindItem.YoutubeUrl %>" />
                        </p>
                    </div>
                </div>
                <hr />
                <div class="text-center">
                    <div class="form-group has-warning">
                        <label class="col-lg-4 col-md-4 control-label">&nbsp;Email:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%#: Item.Email %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;First Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <p>
                                First Name:
                                <asp:TextBox runat="server" ID="tbEditFName" Text="<%#: BindItem.FirstName %>" />
                            </p>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Last Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <p>
                                Last Name:
                                <asp:TextBox runat="server" ID="tbEditLName" Text="<%#: BindItem.LastName %>" />
                            </p>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="text-center">
                    <asp:Button Text="Save" CommandName="Update" runat="server" CssClass="btn btn-success" />
                    <asp:Button Text="Cancel" CommandName="Cancel" runat="server" CssClass="btn btn-danger" />
                </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
