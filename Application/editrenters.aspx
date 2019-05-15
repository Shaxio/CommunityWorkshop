<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editrenters.aspx.cs" Inherits="Application.editrenters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" Text="Editing ID: " ID="lblID" /> <br />
                    <asp:Label runat="server" Text="Users name: " />
                    <asp:TextBox runat="server" ID="txtUserName" Width="14em" />
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save edit" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
</asp:Content>
