<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImgHttpHandlerWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Web Forms stinks</h1>
        <div>
            <label>Enter text</label>
            <input type="text" id="textInput" name="textInput" ID="textInput"/>
            <input type="submit" id="getImage" value="getImage" runat="server" OnServerClick="getImage_OnServerClick"/>
        </div>
        <div runat="server">
            <h2>
                <asp:Label runat="server" ID="result">Resulting Image</asp:Label>

            </h2>
                <asp:Image runat="server" ID="resultImage" />
            <img src="pesho.img?text=12312312" alt="Alternate Text" />
        </div>
    </div>
</asp:Content>
