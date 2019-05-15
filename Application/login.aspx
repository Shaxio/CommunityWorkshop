<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Application.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position:fixed; top: 30%; left:40%;">
        <asp:Login runat="server" ID="inlog" OnAuthenticate="inlog_Authenticate" DestinationPageUrl="index.aspx" BorderWidth="4" TextBoxStyle-BorderWidth="1" BackColor="LightGray" />
        <asp:Button runat="server" ID="btnNewStaff" Text="New Staff Member" OnClick="btnNewStaff_Click" />

    </div>
</asp:Content>
