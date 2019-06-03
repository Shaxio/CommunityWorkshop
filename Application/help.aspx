<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="Application.help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col" style="background-color: darkgray; height: 4em;">
        <a class="gap">Help</a>
        <div class="gap">
            <asp:Button runat="server" ID="btnReturn" Text="Return to Previous Page" OnClick="btnReturn_Click" />
        </div>
    </div>
    <div style="border: 1px solid">
        <asp:Image runat="server" ID="imgHelp" />
    </div>
</asp:Content>
