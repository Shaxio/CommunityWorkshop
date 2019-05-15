<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editcomment.aspx.cs" Inherits="Application.editcomment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" Text="Editing ID: " ID="lblID" /> <br />
                    <asp:Label runat="server" Text="Tool ID: " />
                    <asp:TextBox runat="server" ID="txtToolID" Width="14em" />
                    <br />
                    <asp:Label runat="server" Text="Comment: " />
                    <asp:TextBox runat="server" ID="txtComment" Width="14em" />
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save edit" OnClick="btnSave_Click" />
                    <br />
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
</asp:Content>
