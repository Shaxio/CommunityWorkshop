<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editrental.aspx.cs" Inherits="Application.editrental" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" Text="Editing ID: " ID="lblID" /> <br />
                    <asp:Label runat="server" Text="Tool: " />
                    <asp:DropDownList runat="server" ID="ddlTools" Width="15em" />
                    <br />
                    <asp:Label runat="server" Text="User ID: " />
                    <asp:DropDownList runat="server" ID="ddlUser" Width="12em" />
                    <br />
                    <asp:Label runat="server" Text="Rented: " />
                    <asp:TextBox runat="server" ID="txtRented" Width="14em" TextMode="DateTime" />
                    <br />
                    <asp:Label runat="server" Text="Returned: " />
                    <asp:TextBox runat="server" ID="txtReturned" Width="14em" TextMode="DateTime" />
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save edit" OnClick="btnSave_Click" />
                    <br />
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
</asp:Content>
