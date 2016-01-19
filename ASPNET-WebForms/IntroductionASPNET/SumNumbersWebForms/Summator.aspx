<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summator.aspx.cs" Inherits="SumNumbersWebForms.Summator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="summator" runat="server">
    <div>
        <input type="number" id="numA" value="1" runat="server"/>
        <input type="number" id="numB" value="1" runat="server"/>
        <input type="submit" id="sum" value="Moti" runat="server" OnServerClick="sum_OnServerClick"/>
    </div>
    </form>
    <div runat="server">
        <h2><asp:Label runat="server" ID="result"></asp:Label></h2>
    </div>
</body>
</html>
