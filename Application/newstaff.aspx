<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="newstaff.aspx.cs" Inherits="Application.newstaff"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position:fixed; top: 30%; left:40%;">
        <asp:Label runat="server" Text="User Name: " />
        <asp:TextBox runat="server" ID="txtUsername" />
        <br />
        <asp:Label runat="server" Text="Password: " />
        <asp:TextBox runat="server" ID="txtPassword" />
        <br />
        <asp:Button runat="server" ID="btnNewStaff" Text="Create New Staff Member" OnClick="btnNewStaff_Click" />
        <br />  
        <asp:Label runat="server" ID="txtError" />
        <br /> 
</asp:Content>
