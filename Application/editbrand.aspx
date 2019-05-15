<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editbrand.aspx.cs" Inherits="Application.editbrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" Text="Editing ID: " ID="lblID" /> <br />
                    <asp:Label runat="server" Text="Brand name: " />
                    <asp:TextBox runat="server" ID="txtBrandName" Width="14em" />
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save edit" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
</asp:Content>
